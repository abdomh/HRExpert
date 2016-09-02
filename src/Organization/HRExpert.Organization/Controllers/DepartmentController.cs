using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Organization.BL.Abstractions;
using HRExpert.Organization.DTO;
namespace HRExpert.Organization.Controllers
{
    /// <summary>
    /// Контроллер подразделений
    /// </summary>    
    [Authorize]
    public class DepartmentController : Controller
    {
        private IDepartmentBL departmentBl;
        #region Ctor
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="departmentBl"></param>
        public DepartmentController(IDepartmentBL departmentBl)
        {
            this.departmentBl = departmentBl;
        }
        #endregion
        /// <summary>
        /// Список подразделений по организации
        /// </summary>
        /// <param name="organizationid"></param>
        /// <returns></returns>
        [HttpGet]
        public DepartmentDto[] ByOrganization(int organizationid)
        {
            return departmentBl.ListByOrganization(organizationid).ToArray();
        }
        /// <summary>
        /// Список дочерних
        /// </summary>
        /// <param name="organizationid">Организация</param>
        /// <param name="departmentid">Подразделение</param>
        /// <returns></returns>
        [HttpGet]
        public DepartmentDto[] ByOrganizationAndDepartment(int organizationid,int departmentid)
        {
            return departmentBl.ListByOrganizationAndDepartment(organizationid, departmentid).ToArray();
        }
        /// <summary>
        /// Подразделение по организации и идентификатору
        /// </summary>
        /// <param name="organizationid">Идентификатор организации</param>
        /// <param name="departmentid">Идентификатор подразделения</param>
        /// <returns></returns>
        [HttpGet]
        public DepartmentDto ByOrganizationAndKey(int organizationid,int departmentid)
        {
            return departmentBl.ByOrganizationAndKey(organizationid, departmentid);
        }        
    }
}
