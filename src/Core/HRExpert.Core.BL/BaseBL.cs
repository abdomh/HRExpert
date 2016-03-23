using System.Security.Claims;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Http;
using HRExpert.Core.DTO;
namespace HRExpert.Core.BL
{
    public class BaseBL: Abstractions.IBaseBL
    {
        
        public BaseBL(
            
            )
        {
            
        }
        public static UserDto CurrentUser { get; set; }
        public string GetCurrentUserName() => CurrentUser?.Name;
    }
}
