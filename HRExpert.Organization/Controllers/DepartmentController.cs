using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Organization.BL.Abstractions;
using HRExpert.Organization.DTO;
namespace HRExpert.Organization.Controllers
{
    using Core;
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
        [Route(CoreConstants.Api+
            CoreConstants.version +
            OrganizationConstants.OrganizationList+
            OrganizationConstants.OrganizationKey+
            OrganizationConstants.DepartmentList
            )
        ]
        [HttpGet]
        public DepartmentDto[] ByOrganization(long organizationid)
        {
            return departmentBl.ListByOrganization(organizationid).ToArray();
        }
        /// <summary>
        /// Список дочерних
        /// </summary>
        /// <param name="organizationid">Организация</param>
        /// <param name="departmentid">Подразделение</param>
        /// <returns></returns>
        [Route(CoreConstants.Api +
            CoreConstants.version +
            OrganizationConstants.OrganizationList +
            OrganizationConstants.OrganizationKey +
            OrganizationConstants.DepartmentList +
            OrganizationConstants.DepartmentKey +
            CoreConstants.Childs
            )
        ]
        [HttpGet]
        public DepartmentDto[] ByOrganizationAndDepartment(long organizationid,long departmentid)
        {
            return departmentBl.ListByOrganizationAndDepartment(organizationid, departmentid).ToArray();
        }
        /// <summary>
        /// Подразделение по организации и идентификатору
        /// </summary>
        /// <param name="organizationid">Идентификатор организации</param>
        /// <param name="departmentid">Идентификатор подразделения</param>
        /// <returns></returns>
        [Route(CoreConstants.Api +
            CoreConstants.version +
            OrganizationConstants.OrganizationList +
            OrganizationConstants.OrganizationKey +
            OrganizationConstants.DepartmentList +
            OrganizationConstants.DepartmentKey         
            )
        ]
        [HttpGet]
        public DepartmentDto ByOrganizationAndKey(long organizationid,long departmentid)
        {
            return departmentBl.ByOrganizationAndKey(organizationid, departmentid);
        }
        /*
        #region ONLY FOR ADMIN
        [Authorize(Roles = "Администратор")]
        [HttpGet]
        [Route(OrganizationConstants.DepartmentController)]
        public virtual IEnumerable<DepartmentDto> Get()
        {
            return this.departmentBl.List();
        }
        [Authorize(Roles = "Администратор")]
        [HttpGet]
        [Route(OrganizationConstants.DepartmentController_key)]
        public virtual DepartmentDto Get(long departmentid)
        {
            return this.departmentBl.Read(departmentid);
        }
        [Authorize(Roles = "Администратор")]
        [HttpPost]
        [Route(OrganizationConstants.DepartmentController)]
        public virtual DepartmentDto Post([FromBody]DepartmentDto value)
        {
            return this.departmentBl.Create(value);
        }
        [Authorize(Roles = "Администратор")]
        [HttpPut]
        [Route(OrganizationConstants.DepartmentController)]
        public virtual DepartmentDto Put([FromBody]DepartmentDto value)
        {
            return this.departmentBl.Update(value);
        }
        [Authorize(Roles = "Администратор")]
        [HttpDelete]
        [Route(OrganizationConstants.DepartmentController_key)]
        public virtual DepartmentDto Delete(long departmentid)
        {
            return this.departmentBl.Delete(departmentid);
        }
        #endregion
        */
    }
}
