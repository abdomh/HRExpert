using HRExpert.Core.Data.Models;
using System.Collections.Generic;
namespace HRExpert.Core.Data.Abstractions
{
    /// <summary>
    /// Хранилище учётных данных
    /// </summary>
    public interface ICredentialRepository: ExtCore.Data.Abstractions.IRepository
    {
        /// <summary>
        /// Учётка по логину/паролю
        /// </summary>
        /// <param name="Value">Логин</param>
        /// <param name="Secret">Пароль</param>
        /// <returns>Учётка</returns>
        Credential GetByValueAndSecret(string Value, string Secret);
        /// <summary>
        /// Все записи
        /// </summary>
        /// <returns>Коллекция записей</returns>
        IEnumerable<Credential> All();
        /// <summary>
        /// Создание записи
        /// </summary>
        /// <param name="entity">Сущность</param>
        void Create(Credential entity);
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="CredentialTypeId">Идентификатор типа</param>
        /// <param name="UserId">Идентификатор пользователя</param>
        /// <returns></returns>
        Credential Read(long CredentialTypeId, long UserId);
        /// <summary>
        /// Обновление/редактирование
        /// </summary>
        /// <param name="entity">сущность</param>
        void Update(Credential entity);
        /// <summary>
        /// Удаление по идентификатору
        /// </summary>
        /// <param name="CredentialTypeId">идентификатор типа</param>
        /// <param name="UserId">идентификатор пользователя</param>
        void Delete(long CredentialTypeId, long UserId);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="entity">Сущность</param>
        void Delete(Credential entity);
    }
}
