using System.Collections.Generic;
using HRExpert.Core.DTO;
namespace HRExpert.Core.BL.Abstractions
{
    /// <summary>
    /// Бизнес логика прав
    /// </summary>
    public interface IPermissionBL
    {
        /// <summary>
        /// Список всех прав
        /// </summary>
        /// <returns></returns>
        IEnumerable<PermissionDto> List();
        /// <summary>
        /// Создание прав
        /// </summary>
        /// <param name="dto">Права</param>
        /// <returns>Права</returns>
        PermissionDto Create(PermissionDto dto);
        /// <summary>
        /// Чтение прав
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns></returns>
        PermissionDto Read(long id);
        /// <summary>
        /// Обновление прав
        /// </summary>
        /// <param name="dto">Права</param>
        /// <returns>Права</returns>
        PermissionDto Update(PermissionDto dto);
        /// <summary>
        /// Удаление прав
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Права</returns>
        PermissionDto Delete(long id);
    }
}
