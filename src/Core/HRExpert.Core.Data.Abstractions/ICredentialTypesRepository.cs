using System.Collections.Generic;
using HRExpert.Core.Data.Models;
namespace HRExpert.Core.Data.Abstractions
{
    /// <summary>
    /// Хранилище типов учётных данныъ
    /// </summary>
    public interface ICredentialTypesRepository : ExtCore.Data.Abstractions.IRepository
    {
        /// <summary>
        /// Все записи
        /// </summary>
        /// <returns>Коллекция записей</returns>
        IEnumerable<CredentialType> All();
        /// <summary>
        /// создание
        /// </summary>
        /// <param name="entity">Сущность</param>
        void Create(CredentialType entity);
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="Id">Идентификатор</param>
        /// <returns>Сущность</returns>
        CredentialType Read(long Id);
        /// <summary>
        /// Обновление/редактирование
        /// </summary>
        /// <param name="entity">Сущность</param>
        void Update(CredentialType entity);
        /// <summary>
        /// Удаление по идентификатору
        /// </summary>
        /// <param name="Id">Идентификатор</param>
        void Delete(long Id);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="entity">Сущность</param>
        void Delete(CredentialType entity);
    }
}
