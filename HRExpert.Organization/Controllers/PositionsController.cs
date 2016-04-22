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
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class PositionsController : ReferencyController
    {
        #region Ctor
        public PositionsController(IPositionsBL positionsBl)
            : base(positionsBl)
        {
        }
        #endregion
    }
}
