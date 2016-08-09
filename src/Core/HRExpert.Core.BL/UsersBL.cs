using System.Linq;
using System.Collections.Generic;
using ExtCore.Data.Abstractions;
namespace HRExpert.Core.BL
{
    using Data.Abstractions;
    using Data.Models;
    using Data.Models.Abstractions;
    using DTO;
    using Services.Abstractions;
    using Converters;

    /// <summary>
    /// Бизнес логика пользователей
    /// </summary>
    public class UsersBL: Abstractions.IUsersBL
    {
        /// <summary>
        /// Хранилище пользователей
        /// </summary>
        private IUserRepository userRepository;
        private IRoleRepository roleRepository;
        /// <summary>
        /// Сервис доступа к данным контекста
        /// </summary>
        private IAuthService authService;
        #region Ctor
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="authService"></param>
        public UsersBL(IStorage storage,IAuthService authService)
        {
            this.authService = authService;
            userRepository = storage.GetRepository<IUserRepository>();
            roleRepository = storage.GetRepository<IRoleRepository>();
        }
        #endregion
        #region Public
        /// <summary>
        /// Получение профиля
        /// </summary>
        /// <returns>Профиль</returns>
        public ProfileDto Profile()
        {
            var user = authService.CurrentUser;
            ProfileDto result = new ProfileDto();
            result.UserName = user.Name;
            result.Sections = user.Roles.SelectMany(x => x.Role.Sections)
                                        .Select(x=>x.Section)
                                        .Distinct<Section>(new IdEqualityComparer<long>())
                                        .Select(x => x.Convert())
                                        .ToList();
            result.Sections.ForEach(x =>
            {
                x.Permissions = user.Roles.SelectMany(y => y.Role.Permissions)
                                            .Select(y => y.PermissionType)
                                            .Where(y=>y.SectionId==x.Id)
                                            .Distinct<PermissionType>(new IdEqualityComparer<long>())
                                            .Select(y => y.Convert())
                                            .ToList();
            });  
            return result;
        }
        /// <summary>
        /// Список пользователей
        /// </summary>
        /// <returns>Коллекция записей</returns>
        public virtual IEnumerable<UserDto> List()
        {
            return userRepository.All().Select(x => x.Convert());
        }
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="dto">Пользователь</param>
        /// <returns>Пользователь</returns>
        public virtual UserDto Create(UserDto dto)
        {
            User entity = new User { Name = dto.Name };
            FromDto(entity, dto);
            userRepository.Create(entity);
            return entity.Convert();
        }
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Пользователь</returns>
        public virtual UserDto Read(long id)
        {
            return userRepository.Read(id).Convert();
        }
        /// <summary>
        /// Обновление/редактирование
        /// </summary>
        /// <param name="dto">Пользователь</param>
        /// <returns>Пользователь</returns>
        public virtual UserDto Update(UserDto dto)
        {
            var entity = userRepository.Read(dto.Id);
            this.FromDto(entity, dto);
            userRepository.Update(entity);
            return entity.Convert();
        }
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        public virtual UserDto Delete(long id)
        {
            var entity = userRepository.Read(id);
            entity.Delete = true;
            userRepository.Update(entity);
            return entity.Convert();
        }
        #region Converters
        
        /// <summary>
        /// Конвертер из dto в сущность
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="dto">Пользователь</param>
        public void FromDto(User entity, UserDto dto)        
        {
            entity.Name = dto.Name;
            if(dto.Roles!=null && dto.Roles.Any())
            {
                if (entity.Roles == null) entity.Roles = new List<RoleUser>();
                foreach(var roledto in dto.Roles)
                {
                    if(!entity.Roles.Any(x=>x.RoleId==roledto.Id))
                    {
                        var newrole = new RoleUser();
                        newrole.User = entity;
                        newrole.Role = roleRepository.Read(roledto.Id);
                        entity.Roles.Add(newrole);
                    }
                }
                List<RoleUser> toRemove = new List<RoleUser>();

                foreach(var role in entity.Roles)
                {
                    if(!dto.Roles.Any(x=>x.Id==role.Role.Id))
                    {                        
                        toRemove.Add(role);
                    }
                }
                toRemove.ForEach(x => entity.Roles.Remove(x));
            }
        }
        #endregion
        #endregion
    }
}
