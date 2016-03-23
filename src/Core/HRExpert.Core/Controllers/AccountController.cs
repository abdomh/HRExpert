using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

using HRExpert.Core.BL.Abstractions;
using HRExpert.Core.DTO.ViewModels.Account;
namespace HRExpert.Core.Controllers
{
    public class AccountController : Controller
    {
        #region Ctor
        public AccountController
            (   IAccountBL accountBL,
                IBaseBL baseBL
            )
        {
            this.BaseBl = baseBL;
            this.AccountBL = accountBL;
        }
        #endregion
        #region Private
        private IAccountBL AccountBL;
        private IBaseBL BaseBl;
        #endregion
        public string Hello() => String.Format("Добро пожаловать, {0}!",BaseBl.GetCurrentUserName());

        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SignIn()
        {
            var model = AccountBL.GetSignIn();
            return View(model);
        }
        [HttpPost]
        public IActionResult SignIn(SignInViewModel model)
        {
            var user = AccountBL.SignIn(HttpContext,model);
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
        public IActionResult Register()
        {
            var model = AccountBL.GetRegister();
            return View(model);
        }
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
    }
}
