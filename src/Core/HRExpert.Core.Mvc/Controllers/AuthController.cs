using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ExtCore.Data.Abstractions;
using HRExpert.Core.Data.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Authentication;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace HRExpert.Core.Mvc.Controllers
{
    public class AuthController: Controller
    {
        //public AuthController()
        [AllowAnonymous]
        [HttpGet]
        [Route("/signin")]
        public IActionResult SignIn()
        {
            return this.View();
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("/signin")]
        public IActionResult SignIn(string username, string password)
        {
            return this.View();
        }
    }
}
