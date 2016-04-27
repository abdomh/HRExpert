using System.Collections.Generic;
using HRExpert.Core.Data.Models;
namespace HRExpert.Core.Data.Abstractions
{
    /// <summary>
    /// Хранилище модулей
    /// </summary>
    public interface ISectionRepository : ExtCore.Data.Abstractions.IRepository
    {
        /// <summary>
        /// Все записи
        /// </summary>
        /// <returns>Коллекция записей</returns>
        IEnumerable<Section> All();
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="entity">Сущность</param>
        void Create(Section entity);
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="Id">Идентификатор</param>
        /// <returns>Сущность</returns>
        Section Read(long Id);
        /// <summary>
        /// Обновление/редактирование
        /// </summary>
        /// <param name="entity">Сущность</param>
        void Update(Section entity);
        /// <summary>
        /// Удаление по идентификатору
        /// </summary>
        /// <param name="Id">Идентификатор</param>
        void Delete(long Id);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="entity">Сущность</param>
        void Delete(Section entity);
    }
}
