using Microsoft.AspNet.Mvc;
using HRExpert.Core.BL.Abstractions;
using Microsoft.AspNet.Authorization;
namespace HRExpert.Core.Controllers.api
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class UsersController : ReferencyController
    {
        #region Ctor
        public UsersController(IUsersBL userBL)
            : base(userBL)
        {
        }
        #endregion

    }
}
