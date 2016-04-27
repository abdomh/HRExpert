using System.Collections.Generic;
using HRExpert.Core.Data.Models;
namespace HRExpert.Core.Data.Abstractions
{
    /// <summary>
    /// Хранилище пользователей
    /// </summary>
    public interface IUserRepository: ExtCore.Data.Abstractions.IRepository
    {
        /// <summary>
        /// Профиль пользователя со всеми свойствами
        /// </summary>
        /// <param name="Id">Идентификатор</param>
        /// <returns>Сущность</returns>
        User Profile(long Id);
        /// <summary>
        /// Все записи
        /// </summary>
        /// <returns>Коллекция записей</returns>
        IEnumerable<User> All();
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="entity">Сущность</param>
        void Create(User entity);
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="Id">Идентификатор</param>
        /// <returns>Сущность</returns>
        User Read(long Id);
        /// <summary>
        /// Обновление/редактирование
        /// </summary>
        /// <param name="entity">Сущность</param>
        void Update(User entity);
        /// <summary>
        /// Удаление по идентификатору
        /// </summary>
        /// <param name="Id">Идентификатор</param>
        void Delete(long Id);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="entity">Сущность</param>
        void Delete(User entity);
    }
}
