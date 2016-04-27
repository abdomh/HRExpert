using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using HRExpert.Organization.BL.Abstractions;
using HRExpert.Core.Controllers;
using HRExpert.Organization.DTO;
using HRExpert.Core.DTO;
namespace HRExpert.Organization.Controllers
{
    [Route(OrganizationConstants.PersonsController)]
    public class PersonsController : Controller
    {
        private IPersonBL personsBl;
        #region Ctor
        public PersonsController(IPersonBL personsBl)
        {
            this.personsBl = personsBl;
        }

        #endregion        
        [Route(OrganizationConstants.PersonsControllerPath)]
        [HttpGet]
        public PersonDto[] PersonsList(long organizationid,long departmentid,long positionid)
        {
            return personsBl.GetByStaffEstablishedPost(organizationid, departmentid, positionid).ToArray();
        }
        [Route(OrganizationConstants.PersonsControllerPath_key)]
        [HttpGet]
        public PersonDto ByStaffEstablishedPostAndId(long organizationid, long departmentid, long positionid, long personid)
        {
            return personsBl.GetByStaffEstablishedPostAndId(organizationid, departmentid, positionid, personid);
        }
    }
}
