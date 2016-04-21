using Microsoft.AspNet.Mvc;
using HRExpert.Core.BL.Abstractions;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Authentication.JwtBearer;
using HRExpert.Core.DTO;

namespace HRExpert.Core.Controllers.api
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Администратор")]
    public class UsersController : ReferencyController
    {
        #region Ctor
        public UsersController(IUsersBL userBL)
            : base(userBL)
        {
        }
        #endregion
        
        [NonAction]
        public override IdNameDto Post([FromBody] IdNameDto value)
        {
            return base.Post(value);
        }
        [HttpPost]
        public IdNameDto Post([FromBody] UserDto value)
        {
            return base.Post(value);
        }
        [NonAction]
        public override IdNameDto Put([FromBody] IdNameDto value)
        {
            return base.Put(value);
        }
        [HttpPut]
        public IdNameDto Put([FromBody] UserDto value)
        {
            return base.Put(value);
        }
    }
}
