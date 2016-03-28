using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using HRExpert.Core.BL.Abstractions;
using HRExpert.Core.DTO.ViewModels.Account;
using HRExpert.Core.Abstractions;
namespace HRExpert.Core.Controllers.api
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        #region Ctor
        public LoginController(IAccountBL accountBL)
        {
            this.accountBL = accountBL;
        }
        #endregion
        #region Private
        private IAccountBL accountBL;
        #endregion
        #region Public
        public IAccountBL AccountBL
        {
            get { return accountBL; }
        }
        #endregion
        #region Actions
       
        [HttpPost]
        [AllowAnonymous]
        public IUser SignIn(SignInViewModel model)
        {
            return AccountBL.SignIn(model);
        }
        [HttpPost]
        [AllowAnonymous]
        public bool Register(RegisterViewModel model)
        {
            var user = AccountBL.Register(model);
            return user != null ? true : false;
        }
        #endregion
    }
}
