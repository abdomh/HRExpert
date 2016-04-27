using System.Collections.Generic;
using HRExpert.Core.DTO;
namespace HRExpert.Core.BL.Abstractions
{
    /// <summary>
    /// Бизнес логика модулей
    /// </summary>
    public interface ISectionBL 
    {
        /// <summary>
        /// Список модулей
        /// </summary>
        /// <returns></returns>
        IEnumerable<SectionDto> List();
        /// <summary>
        /// Создание модуля
        /// </summary>
        /// <param name="dto">Модуль</param>
        /// <returns>Модуль</returns>
        SectionDto Create(SectionDto dto);
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модуль</returns>
        SectionDto Read(long id);
        /// <summary>
        /// Обновление/редактирование
        /// </summary>
        /// <param name="dto">Модуль</param>
        /// <returns>Модуль</returns>
        SectionDto Update(SectionDto dto);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Модуль</returns>
        SectionDto Delete(long id);
    }
}
