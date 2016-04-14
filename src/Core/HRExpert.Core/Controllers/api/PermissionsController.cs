using Microsoft.AspNet.Mvc;
using HRExpert.Core.BL.Abstractions;
using Microsoft.AspNet.Authorization;
using HRExpert.Core.DTO;

namespace HRExpert.Core.Controllers.api
{
    [Route("api/[controller]")]
    [Authorize]
    public class PermissionsController : ReferencyController
    {
        #region Ctor
        public PermissionsController(IPermissionBL permissionsBl)
            : base(permissionsBl)
        {
        }
        #endregion
        [NonAction]
        public override IdNameDto Post([FromBody] IdNameDto value)
        {
            return base.Post(value);
        }
        [HttpPost]
        public IdNameDto Post([FromBody] PermissionDto value)
        {
            return base.Post(value);
        }
        [NonAction]
        public override IdNameDto Put([FromBody] IdNameDto value)
        {
            return base.Put(value);
        }
        [HttpPut]
        public IdNameDto Put([FromBody] PermissionDto value)
        {
            return base.Put(value);
        }
    }
}
