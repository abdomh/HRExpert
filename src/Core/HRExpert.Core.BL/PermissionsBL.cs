using System.Collections.Generic;
using System.Linq;
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
    public class PermissionsBL : Abstractions.IPermissionBL
    {
        /// <summary>
        /// Хранилище типов прав
        /// </summary>
        private IPermissionTypesRepository permissionTypeRepository;
        /// <summary>
        /// Хранилище модулей
        /// </summary>
        private ISectionRepository sectionRepository;
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
        public PermissionsBL(IStorage storage, IAuthService authService)
        {
            permissionTypeRepository = storage.GetRepository<IPermissionTypesRepository>();
            sectionRepository = storage.GetRepository<ISectionRepository>();
            this.authService = authService;
        }
        #endregion        
        #region Public
        /// <summary>
        /// Список всех прав
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<PermissionDto> List()
        {
            return permissionTypeRepository.All().Select(x => ToDto(x));
        }
        /// <summary>
        /// Создание прав
        /// </summary>
        /// <param name="dto">Права</param>
        /// <returns>Права</returns>
        public virtual PermissionDto Create(PermissionDto dto)
        {
            PermissionType entity = new PermissionType { Name = dto.Name };
            FromDto(entity, dto);
            permissionTypeRepository.Create(entity);
            return ToDto(entity);
        }
        /// <summary>
        /// Чтение прав
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        public virtual PermissionDto Read(long id)
        {
            return ToDto(permissionTypeRepository.Read(id));
        }
        /// <summary>
        /// Обновление прав
        /// </summary>
        /// <param name="dto">Права</param>
        /// <returns>Права</returns>
        public virtual PermissionDto Update(PermissionDto dto)
        {
            var entity = permissionTypeRepository.Read(dto.Id);
            this.FromDto(entity, dto);
            permissionTypeRepository.Update(entity);
            return ToDto(entity);
        }
        /// <summary>
        /// Удаление прав
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Права</returns>
        public virtual PermissionDto Delete(long id)
        {
            var entity = permissionTypeRepository.Read(id);
            entity.Delete = true;
            permissionTypeRepository.Update(entity);
            return ToDto(entity);
        }
        #region Converters
        /// <summary>
        /// Конвертер прав из сущности в dto
        /// </summary>
        /// <param name="entity">сущность</param>
        /// <returns></returns>
        public PermissionDto ToDto(PermissionType entity)
        {
            PermissionDto result = new PermissionDto();
            result.Id = entity.Id;
            result.Name = entity.Name;          
            return result;
        }
        /// <summary>
        /// Конвертер прав из dto в сущность
        /// </summary>
        /// <param name="entity">сущность</param>
        /// <param name="dto">права</param>
        public void FromDto(PermissionType entity, PermissionDto dto)
        {            
            entity.Name = dto.Name;
            if (dto.Section!=null && (entity.Section == null || entity.SectionId != dto.Section.Id))
                entity.Section = sectionRepository.Read(dto.Section.Id);
        }
        #endregion
        #endregion
    }
}
