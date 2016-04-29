using System.Linq;
using System.Collections.Generic;
using ExtCore.Data.Abstractions;
using HRExpert.Core.Data.Abstractions;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Services.Abstractions;
using HRExpert.Core.DTO;
namespace HRExpert.Core.BL
{
    /// <summary>
    /// Бизнес логика прав
    /// </summary>
    public class RolesBL: Abstractions.IRoleBL
    {
        /// <summary>
        /// Хранилище ролей
        /// </summary>
        private IRoleRepository roleRepository;
        private IRoleUserRepository roleUserRepository;
        #region Ctor
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="authService"></param>
        public RolesBL(IStorage storage,IAuthService authService)
        {
            roleRepository = storage.GetRepository<IRoleRepository>();
            roleUserRepository = storage.GetRepository<IRoleUserRepository>();
        }
        #endregion     
        #region Public
        /// <summary>
        /// Список ролей
        /// </summary>
        /// <returns>Коллекция ролей</returns>
        public virtual IEnumerable<RoleDto> List()
        {
            return roleRepository.All().Select(x => ToDto(x));
        }
        /// <summary>
        /// Создание роли
        /// </summary>
        /// <param name="dto">Роль</param>
        /// <returns>Роль</returns>
        public virtual RoleDto Create(RoleDto dto)
        {
            Role entity = new Role { Name = dto.Name };
            FromDto(entity, dto);
            roleRepository.Create(entity);
            return ToDto(entity);
        }
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Роль</returns>
        public virtual RoleDto Read(long id)
        {
            return ToDto(roleRepository.Read(id));
        }
        /// <summary>
        /// Обновление/редактирование роли
        /// </summary>
        /// <param name="dto">Роль</param>
        /// <returns>Роль</returns>
        public virtual RoleDto Update(RoleDto dto)
        {
            var entity = roleRepository.Read(dto.Id);
            this.FromDto(entity, dto);
            roleRepository.Update(entity);
            return ToDto(entity);
        }
        /// <summary>
        /// Удаление роли
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Роль</returns>
        public virtual RoleDto Delete(long id)
        {
            var entity = roleRepository.Read(id);
            entity.Delete = true;
            roleRepository.Update(entity);
            return ToDto(entity);
        }
        /// <summary>
        /// Создание/добавление роли пользователю
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        public virtual RoleDto CreateRoleToUser(long userid, RoleDto dto)
        {
            if(dto.Id==0)
            {
                dto = Create(dto);
            }
            var existed = roleUserRepository.Read(userid, dto.Id);
            if (existed != null) return dto;
            RoleUser roleuser = new RoleUser { RoleId = dto.Id, UserId = userid };
            roleUserRepository.Create(roleuser);
            return dto;
        }
        /// <summary>
        /// Редактирование ролей списком
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        public virtual IEnumerable<RoleDto> EditRolesList(long userid, List<RoleDto> roles)
        {
            List<RoleUser> userroles = roleUserRepository.ListByUser(userid);
            foreach (var dto in roles)
            {
                if (!userroles.Any(x => x.RoleId == dto.Id))
                    CreateRoleToUser(userid, dto);
            }
            foreach (var role in userroles)
            {
                if (!roles.Any(x => x.Id == role.RoleId))
                    roleUserRepository.Delete(role);
            }
            return roles;
        }
        /// <summary>
        /// Удаление роли у пользователя
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="dto"></param>
        public virtual void RemoveRoleFromUser(long userid, RoleDto dto)
        {
            var existed = roleUserRepository.Read(userid, dto.Id);
            if (existed == null) return;
            roleUserRepository.Delete(existed);
        }
        #region Converters
        /// <summary>
        /// Конвертер из сущности в dto
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <returns>Роль</returns>
        public RoleDto ToDto(Role entity)
        {
            RoleDto result = new RoleDto();
            result.Id = entity.Id;
            result.Name = entity.Name;
            result.Permissions = entity.Permissions?.Select(x => new PermissionDto { Id = x.PermissionType.Id, Name = x.PermissionType.Name, Section = new SectionDto { Name = x.PermissionType.Section.Name, Id = x.PermissionType.Section.Id } }).ToList();
            return result;
        }
        /// <summary>
        /// Конвертер из dto в сущность
        /// </summary>
        /// <param name="entity">сущность</param>
        /// <param name="dto">роль</param>
        public void FromDto(Role entity, RoleDto dto)
        {
            entity.Name = dto.Name;            
        }
        #endregion
        #endregion   
    }
}
