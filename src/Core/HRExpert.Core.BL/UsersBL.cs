using System.Linq;
using System.Collections.Generic;
using ExtCore.Data.Abstractions;
using HRExpert.Core.Data.Abstractions;
using HRExpert.Core.Data.Models;
using HRExpert.Core.DTO;
using HRExpert.Core.Services.Abstractions;
namespace HRExpert.Core.BL
{
    /// <summary>
    /// Бизнес логика пользователей
    /// </summary>
    public class UsersBL: Abstractions.IUsersBL
    {
        /// <summary>
        /// Хранилище пользователей
        /// </summary>
        private IUserRepository userRepository;
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
            result.Roles = user.Roles.Select(x => new RoleDto
            {
                Id = x.RoleId,
                Name = x.Role.Name,
                Permissions = x.Role.Permissions.Select(permission => new PermissionDto { Id = permission.PermissionTypeId, Name = permission.PermissionType.Name, }).ToList(),
                Sections = x.Role.Sections.Select(section => new SectionDto { Id = section.SectionId, Name = section.Section.Name, RouteName = section.Section.RouteName }).ToList()
            }).ToList();           
            return result;
        }
        /// <summary>
        /// Список пользователей
        /// </summary>
        /// <returns>Коллекция записей</returns>
        public virtual IEnumerable<UserDto> List()
        {
            return userRepository.All().Select(x => ToDto(x));
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
            return ToDto(entity);
        }
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Пользователь</returns>
        public virtual UserDto Read(long id)
        {
            return ToDto(userRepository.Read(id));
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
            return ToDto(entity);
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
            return ToDto(entity);
        }
        #region Converters
        /// <summary>
        /// Конвертер из сущности в dto
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <returns>Пользователь</returns>
        public UserDto ToDto(User entity)
        {
            UserDto result = new UserDto();
            result.Id = entity.Id; 
            result.Name = entity.Name;
            return result;
        }
        /// <summary>
        /// Конвертер из dto в сущность
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="dto">Пользователь</param>
        public void FromDto(User entity, UserDto dto)        
        {           
            entity.Name = dto.Name;                       
        }
        #endregion
        #endregion
    }
}
