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
        #region Ctor
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="authService"></param>
        public RolesBL(IStorage storage,IAuthService authService)
        {
            roleRepository = storage.GetRepository<IRoleRepository>();
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
