using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using HRExpert.Core.BL.Abstractions;

namespace HRExpert.Core.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class RolesController : ReferencyController
    {
        #region Ctor
        public RolesController(IRoleBL roleBl)
            :base(roleBl)
        {
        }
        #endregion
        
    }
}
