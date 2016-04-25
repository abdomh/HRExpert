using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using HRExpert.Organization.BL.Abstractions;
using HRExpert.Organization.DTO;
namespace HRExpert.Organization.Controllers
{
    [Route(OrganizationConstants.DepartmentController)]
    [AllowAnonymous]
    public class DepartmentController : Controller
    {
        private IDepartmentBL departmentBl;
        #region Ctor
        public DepartmentController(IDepartmentBL departmentBl)
        {
            this.departmentBl = departmentBl;
        }
        #endregion
        [Route(OrganizationConstants.DepartmentControllerPath)]
        [HttpGet]
        public DepartmentDto[] ByOrganization(long organizationid)
        {
            return departmentBl.ListByOrganization(organizationid).ToArray();
        }
        [HttpGet]
        [Route(OrganizationConstants.DepartmentController)]
        public virtual IEnumerable<DepartmentDto> Get()
        {
            return this.departmentBl.List();
        }
        [HttpGet]
        [Route(OrganizationConstants.DepartmentController_key)]
        public virtual DepartmentDto Get(long departmentid)
        {
            return this.departmentBl.Read(departmentid);
        }
        [HttpPost]
        [Route(OrganizationConstants.DepartmentController)]
        public virtual DepartmentDto Post([FromBody]DepartmentDto value)
        {
            return this.departmentBl.Create(value);
        }
        [HttpPut]
        [Route(OrganizationConstants.DepartmentController)]
        public virtual DepartmentDto Put([FromBody]DepartmentDto value)
        {
            return this.departmentBl.Update(value);
        }
        [HttpDelete]
        [Route(OrganizationConstants.DepartmentController_key)]
        public virtual DepartmentDto Delete(long departmentid)
        {
            return this.departmentBl.Delete(departmentid);
        }
    }
}
