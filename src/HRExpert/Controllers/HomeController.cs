﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HRExpert.Controllers
{
    /// <summary>
    /// Тест контроллер
    /// </summary>
    [AllowAnonymous]
    public class HomeController:Controller
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <returns>string if ok</returns>
        [HttpGet]        
        public IActionResult Index()
        {
            return View();
        }
    }
}