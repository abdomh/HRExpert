using System.Collections.Generic;
using HRExpert.Core.DTO;
namespace HRExpert.Core.BL.Abstractions
{
    /// <summary>
    /// Бизнес логика ролей
    /// </summary>
    public interface IRoleBL
    {
        /// <summary>
        /// Список ролей
        /// </summary>
        /// <returns>Коллекция ролей</returns>
        IEnumerable<RoleDto> List();
        /// <summary>
        /// Создание роли
        /// </summary>
        /// <param name="dto">Роль</param>
        /// <returns>Роль</returns>
        RoleDto Create(RoleDto dto);
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Роль</returns>
        RoleDto Read(long id);
        /// <summary>
        /// Обновление/редактирование роли
        /// </summary>
        /// <param name="dto">Роль</param>
        /// <returns>Роль</returns>
        RoleDto Update(RoleDto dto);
        /// <summary>
        /// Удаление роли
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Роль</returns>
        RoleDto Delete(long id);
    }
}
