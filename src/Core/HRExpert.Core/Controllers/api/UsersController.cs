using Microsoft.AspNet.Mvc;
using HRExpert.Core.BL.Abstractions;

namespace HRExpert.Core.Controllers.api
{
    [Route("api/[controller]")]
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
