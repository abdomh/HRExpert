using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using HRExpert.Organization.BL.Abstractions;
using HRExpert.Core.Controllers;
namespace HRExpert.Organization.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class OrganizationController : ReferencyController
    {
        #region Ctor
        public OrganizationController(IOrganizationBL organizationBl)
            : base(organizationBl)
        {
        }
        #endregion

    }
}
