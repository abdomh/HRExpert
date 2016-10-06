﻿// Copyright © 2015 Dmitry Sikorsky. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Platformus;
using Platformus.Security;
using Platformus.Security.Backend.ViewModels.Account;
using Platformus.Security.Data.Models;

namespace HRExpert.Organization.Controllers
{
    
    public class AccountController : Platformus.Barebone.Controllers.ControllerBase
    {
        public AccountController(IStorage storage)
          : base(storage)
        {
        }

        [HttpGet]
        [ImportModelStateFromTempData]
        [AllowAnonymous]
        public IActionResult SignIn()
        {
            return this.View();
        }

        [HttpPost]
        [ExportModelStateToTempData]
        [AllowAnonymous]
        public IActionResult SignIn(SignInViewModel signIn)
        {
            if (this.ModelState.IsValid)
            {
                UserManager userManager = new UserManager(this);
                User user = userManager.Validate("Email", signIn.Email, signIn.Password);

                if (user != null)
                {
                    userManager.SignIn(user);
                    return this.RedirectToAction("Index", "Home");
                }
            }

            return this.CreateRedirectToSelfResult();
        }

        [HttpGet]
        public IActionResult SignOut()
        {
            new UserManager(this).SignOut();
            return this.RedirectToAction("SignIn");
        }
    }
}