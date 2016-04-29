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

        /// <summary>
        /// Создание/добавление роли пользователю
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="dto"></param>
        /// <returns></returns>
        RoleDto CreateRoleToUser(long userid, RoleDto dto);
        /// <summary>
        /// Удаление роли у пользователя
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="dto"></param>
        void RemoveRoleFromUser(long userid, RoleDto dto);
        /// <summary>
        /// Редактирование ролей списком
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
        IEnumerable<RoleDto> EditRolesList(long userid, List<RoleDto> roles);
    }
}
