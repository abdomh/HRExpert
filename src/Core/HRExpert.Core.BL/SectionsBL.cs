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
    /// Бизнес логика модулей
    /// </summary>
    public class SectionsBL :  Abstractions.ISectionBL
    {
        /// <summary>
        /// Хранилище модулей
        /// </summary>
        private ISectionRepository sectionRepository;
        #region Ctor
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="authService"></param>
        public SectionsBL(IStorage storage, IAuthService authService)
        {
            sectionRepository = storage.GetRepository<ISectionRepository>();
        }
        #endregion      
        #region Public
        /// <summary>
        /// Список модулей
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<SectionDto> List()
        {
            return sectionRepository.All().Select(x => ToDto(x));
        }
        /// <summary>
        /// Создание модуля
        /// </summary>
        /// <param name="dto">Модуль</param>
        /// <returns>Модуль</returns>
        public virtual SectionDto Create(SectionDto dto)
        {
            Section entity = new Section { Name = dto.Name };
            FromDto(entity, dto);
            sectionRepository.Create(entity);
            return ToDto(entity);
        }
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модуль</returns>
        public virtual SectionDto Read(long id)
        {
            return ToDto(sectionRepository.Read(id));
        }
        /// <summary>
        /// Обновление/редактирование
        /// </summary>
        /// <param name="dto">Модуль</param>
        /// <returns>Модуль</returns>
        public virtual SectionDto Update(SectionDto dto)
        {
            var entity = sectionRepository.Read(dto.Id);
            this.FromDto(entity, dto);
            sectionRepository.Update(entity);
            return ToDto(entity);
        }
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модуль</returns>
        public virtual SectionDto Delete(long id)
        {
            var entity = sectionRepository.Read(id);
            entity.Delete = true;
            sectionRepository.Update(entity);
            return ToDto(entity);
        }
        #region Converters
        /// <summary>
        /// Конвертер из сущности в dto
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <returns>Модуль</returns>
        public SectionDto ToDto(Section entity)
        {
            SectionDto result = new SectionDto();
            result.Id = entity.Id;
            result.Name = entity.Name;
            return result;
        }
        /// <summary>
        /// Конвертер из dto в сущность
        /// </summary>
        /// <param name="entity">Сущность</param>
        /// <param name="dto">Модуль</param>
        public void FromDto(Section entity, SectionDto dto)
        {
            entity.Name = dto.Name;
        }
        #endregion
        #endregion     
    }
}
