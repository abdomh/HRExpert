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
        IEnumerable<DepartmentDto> ListByOrganization(int OrganizationId);
        IEnumerable<DepartmentDto> ListByOrganizationAndDepartment(int OrganizationId, int DepartmentId);
        /// <summary>
        /// Подразделение по организации и ключу
        /// </summary>
        /// <param name="organizationid"></param>
        /// <param name="departmentid"></param>
        /// <returns></returns>
        DepartmentDto ByOrganizationAndKey(int organizationid, int departmentid);
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
        DepartmentDto Read(int id);
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
        DepartmentDto Delete(int id);
    }
}
