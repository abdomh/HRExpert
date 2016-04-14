using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Authentication.JwtBearer;
using HRExpert.Core.BL.Abstractions;
using HRExpert.Core.DTO;
namespace HRExpert.Core.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Администратор")]
    public class RolesController : ReferencyController
    {
        #region Ctor
        public RolesController(IRoleBL roleBl)
            :base(roleBl)
        {
        }
        #endregion
        [NonAction]
        public override IdNameDto Post([FromBody] IdNameDto value)
        {
            return base.Post(value);
        }
        [HttpPost]
        public IdNameDto Post([FromBody] RoleDto value)
        {
            return base.Post(value);
        }
        [NonAction]
        public override IdNameDto Put([FromBody] IdNameDto value)
        {
            return base.Put(value);
        }
        [HttpPut]
        public IdNameDto Put([FromBody] RoleDto value)
        {
            return base.Put(value);
        }
    }
}
