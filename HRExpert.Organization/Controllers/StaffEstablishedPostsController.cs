using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace HRExpert.Organization.Controllers
{
    using DTO;
    using BL.Abstractions;
    using Core;
    [Authorize]
    public class StaffEstablishedPostsController:Controller
    {
        private IStaffEstablishedPostBL staffEstablishedPostBl;
        #region Ctor
        public StaffEstablishedPostsController(IStaffEstablishedPostBL staffEstablishedPostBl)            
        {
            this.staffEstablishedPostBl = staffEstablishedPostBl;
        }
        #endregion        
        [Route(CoreConstants.Api +
            CoreConstants.version +
            OrganizationConstants.OrganizationList +
            OrganizationConstants.OrganizationKey +
            OrganizationConstants.DepartmentList +
            OrganizationConstants.DepartmentKey +
            OrganizationConstants.StaffEstablishedPostsList
            )
        ]
        [HttpGet]
        public StaffEstablishedPostDto[] List(long departmentid)
        {
            return this.staffEstablishedPostBl.GetByDepartment(departmentid)?.ToArray();
        }

        [Route(CoreConstants.Api +
            CoreConstants.version +
            OrganizationConstants.OrganizationList +
            OrganizationConstants.OrganizationKey +
            OrganizationConstants.DepartmentList +
            OrganizationConstants.DepartmentKey +
            OrganizationConstants.StaffEstablishedPostsList +
            OrganizationConstants.PositionsKey
            )
        ]
        [HttpGet]
        public StaffEstablishedPostDto Read(long departmentid, long positionid)
        {
            return this.staffEstablishedPostBl.GetByDepartmentAndPosition(departmentid, positionid);
        }
    }
}
