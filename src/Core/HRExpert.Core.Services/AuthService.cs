using System.Security.Claims;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Authentication.Cookies;
using HRExpert.Core.Data.Models.Abstractions;

namespace HRExpert.Core.Services
{
    /// <summary>
    /// Сервис аутентификации
    /// </summary>
    public class AuthService: Abstractions.IAuthService
    {
        public AuthService()
        {
        }
        /// <summary>
        /// Текущий контекст
        /// </summary>
        public HttpContext CurrentContext
        {
            get;set;
        }
        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="user">Пользователь для авторизации</param>
        public async void SignIn(IUser user)
        {
            Claim[] claims = new[]
              {
                new Claim(ClaimTypes.Name, string.Format("user{0}{1}", user.Id,user.Name))
              };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await CurrentContext.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }
        /// <summary>
        /// Выход
        /// </summary>
        public async void SignOut()
        {
            await CurrentContext.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}
