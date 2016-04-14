using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;

namespace HRExpert.Controllers
{
    [Route("Test")]
    [AllowAnonymous]
    public class TestController:Controller
    {
        [HttpGet]
        public string Index()
        {
            return "Application is working!";
        }
    }
}
