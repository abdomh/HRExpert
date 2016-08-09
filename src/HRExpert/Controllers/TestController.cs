using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HRExpert.Controllers
{
    /// <summary>
    /// Тест контроллер
    /// </summary>
    [Route("Test")]
    [AllowAnonymous]
    public class TestController:Controller
    {
        /// <summary>
        /// Main
        /// </summary>
        /// <returns>string if ok</returns>
        [HttpGet]        
        public string Index()
        {
            return "Application is working!";
        }
    }
}
