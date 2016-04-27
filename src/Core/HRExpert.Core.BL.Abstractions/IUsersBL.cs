using System.Collections.Generic;
using HRExpert.Core.DTO;
namespace HRExpert.Core.BL.Abstractions
{
    /// <summary>
    /// Бизнес логика для пользователей
    /// </summary>
    public interface IUsersBL
    {
        /// <summary>
        /// Получение профиля пользователя
        /// </summary>
        /// <returns>Профиль</returns>
        ProfileDto Profile();
        /// <summary>
        /// Список пользователей
        /// </summary>
        /// <returns>Коллекция записей</returns>
        IEnumerable<UserDto> List();
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="dto">Пользователь</param>
        /// <returns>Пользователь</returns>
        UserDto Create(UserDto dto);
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Пользователь</returns>
        UserDto Read(long id);
        /// <summary>
        /// Обновление/редактирование
        /// </summary>
        /// <param name="dto">Пользователь</param>
        /// <returns>Пользователь</returns>
        UserDto Update(UserDto dto);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        UserDto Delete(long id);
    }
}
