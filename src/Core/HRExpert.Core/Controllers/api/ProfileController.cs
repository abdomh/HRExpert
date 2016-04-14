using Microsoft.AspNet.Mvc;
using HRExpert.Core.BL.Abstractions;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Authentication.JwtBearer;
using HRExpert.Core.DTO;

namespace HRExpert.Core.Controllers.api
{
    [Route("api/[controller]")]
    [Authorize]
    public class ProfileController
    {
        private IUsersBL userBl;
        public ProfileController(IUsersBL userBl)
        {
            this.userBl = userBl;
        }
        public ProfileDto Profile()
        {
            return userBl.Profile();
        }
    }
}
