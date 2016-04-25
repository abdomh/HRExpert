using Microsoft.AspNet.Mvc;
using HRExpert.Organization.BL.Abstractions;
using HRExpert.Organization.DTO;
using Microsoft.AspNet.Authorization;
namespace HRExpert.Organization.Controllers
{
    [AllowAnonymous]
    [Route(OrganizationConstants.StaffEstablishedPostsController)]
    public class StaffEstablishedPostsController:Controller
    {
        private IStaffEstablishedPostBL staffEstablishedPostBl;
        #region Ctor
        public StaffEstablishedPostsController(IStaffEstablishedPostBL staffEstablishedPostBl)            
        {
            this.staffEstablishedPostBl = staffEstablishedPostBl;
        }
        #endregion        
        [Route(OrganizationConstants.StaffEstablishedPostsControllerPath)]
        [HttpGet]
        public StaffEstablishedPostDto[] List(long departmentid)
        {
            return this.staffEstablishedPostBl.GetByDepartment(departmentid).ToArray();
        }
        
        [Route(OrganizationConstants.StaffEstablishedPostsControllerPath_key)]
        [HttpGet]
        public StaffEstablishedPostDto Read(long departmentid, long positionid)
        {
            return this.staffEstablishedPostBl.GetByDepartmentAndPosition(departmentid, positionid);
        }
    }
}
