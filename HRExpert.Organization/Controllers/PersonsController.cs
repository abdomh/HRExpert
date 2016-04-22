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
    public class PersonsController : ReferencyController
    {
        #region Ctor
        public PersonsController(IPersonBL personsBl)
            : base(personsBl)
        {
        }
        #endregion
        [Route("/api/Organization/Departments/{departmentid}/StaffEstablishedPost/{positionid}/Persons")]
        [HttpGet]
        public IdNameDto[] PersonsList(long departmentid,long positionid)
        {
            return ((IPersonBL)ReferencyBL).GetByStaffEstablishedPost(departmentid,positionid).ToArray();
        }
    }
}
