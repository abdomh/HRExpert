using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

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
