using System;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using HRExpert.Core.BL.Abstractions;
using HRExpert.Core.DTO.ViewModels.Account;
namespace HRExpert.Core.Controllers
{    
    public class AccountController : BaseController
    {
        #region Ctor
        public AccountController(   
            IAccountBL accountBL,
            IBaseBL baseBL
            )
            :base(baseBL)
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
        public string Hello() => String.Format("Добро пожаловать, {0}!",BaseBl.GetCurrentUserName());
        
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SignIn()
        {
            var model = AccountBL.GetSignIn();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult SignIn(SignInViewModel model)
        {
            var user = AccountBL.SignIn(model);
            if(user!=null)
            {                
                return RedirectToAction("Hello");
            }
            else
            {
                ModelState.AddModelError("Login", "Пользователь не найден");
                return View(model);
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            var model = AccountBL.GetRegister();
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Register(RegisterViewModel model)
        {
            var user=AccountBL.Register(model);
            if (user != null)
            {
                return RedirectToAction("Hello");
            }
            else
            {
                ModelState.AddModelError("Login", "Пользователь не найден");
                return View(model);
            }
        }
        #endregion
    }
}
