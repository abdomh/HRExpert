using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace HRExpert.Core.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public ActionResult SignIn()
        {
          return View();
        }
        public string Test() => "TEST!!!";
    }
}
