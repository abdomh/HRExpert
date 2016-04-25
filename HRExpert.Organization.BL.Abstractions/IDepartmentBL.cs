using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.DTO;
namespace HRExpert.Organization.BL.Abstractions
{
    public interface IDepartmentBL
    {
        /// <summary>
        /// Все
        /// </summary>
        /// <returns></returns>
        IEnumerable<DepartmentDto> List();
        /// <summary>
        /// Все по организации
        /// </summary>
        /// <param name="OrganizationId"></param>
        /// <returns></returns>
        IEnumerable<DepartmentDto> ListByOrganization(long OrganizationId);
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        DepartmentDto Create(DepartmentDto dto);
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DepartmentDto Read(long id);
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        DepartmentDto Update(DepartmentDto dto);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        DepartmentDto Delete(long id);
    }
}
