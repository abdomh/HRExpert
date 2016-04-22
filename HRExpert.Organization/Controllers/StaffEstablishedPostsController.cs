using Microsoft.AspNet.Mvc;
using HRExpert.Organization.BL.Abstractions;
using HRExpert.Organization.DTO;
using Microsoft.AspNet.Authorization;
namespace HRExpert.Organization.Controllers
{
    [AllowAnonymous]
    public class StaffEstablishedPostsController:Controller
    {
        private IStaffEstablishedPostBL staffEstablishedPostBl;
        #region Ctor
        public StaffEstablishedPostsController(IStaffEstablishedPostBL staffEstablishedPostBl)            
        {
            this.staffEstablishedPostBl = staffEstablishedPostBl;
        }
        #endregion
        [Route("/api/Organization/Departments/{departmentid}/StaffEstablishedPosts")]
        [HttpGet]
        public StaffEstablishedPostDto[] List(long departmentid)
        {
            return this.staffEstablishedPostBl.GetByDepartment(departmentid).ToArray();
        }
        [Route("/api/Organization/Departments/{departmentid}/StaffEstablishedPosts/{positionid}")]
        [HttpGet]
        public StaffEstablishedPostDto Read(long departmentid, long positionid)
        {
            return this.staffEstablishedPostBl.GetByDepartmentAndPosition(departmentid,positionid);
        }
    }
}
