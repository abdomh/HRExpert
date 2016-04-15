using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Authentication.JwtBearer;
using HRExpert.Core.BL.Abstractions;

namespace HRExpert.Core.Controllers
{
    [Route("api/[controller]")]
    public class SectionsController : ReferencyController
    {
        #region Ctor
        public SectionsController(ISectionBL moduleBl)
            : base(moduleBl)
        {
        }
        #endregion

    }
}
