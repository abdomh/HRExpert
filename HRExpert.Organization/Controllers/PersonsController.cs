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
        public IdNameDto[] PersonsList(long departmentid,long positionid)
        {
            return personsBl.GetByStaffEstablishedPost(departmentid, positionid).ToArray();
        }
    }
}
