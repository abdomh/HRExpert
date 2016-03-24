using System.Security.Claims;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Authentication.Cookies;
using core = HRExpert.Core.Abstractions;
using HRExpert.Core.Abstractions.Enum;
using HRExpert.Core.Services.Abstractions;
namespace HRExpert.Core.Services
{
    /// <summary>
    /// Сервис аутентификации
    /// </summary>
    public class AuthService: Abstractions.IAuthService
    {
        private ISerializationService SerializationServ;

        public AuthService( Abstractions.ISerializationService serializationServ)
        {
            SerializationServ = serializationServ;
        }
        /// <summary>
        /// Текущий контекст
        /// </summary>
        public HttpContext CurrentContext
        {
            get; set;
        }
        public core.IUser CurrentUser
        {
            get
            {
                string UserData = CurrentContext.User.Claims.Where(x => x.Type == ClaimTypes.UserData).First().Value;
                core.IUser result = SerializationServ.Deserialize<core.IUser>(UserData);
                return result;
            }
        }
        public void SetCurrentContext(HttpContext context)
        {
            CurrentContext = context;
        }
        /// <summary>
        /// Авторизация
        /// </summary>
        /// <param name="user">Пользователь для авторизации</param>
        public async void SignIn(core.IUser user)
        {
            Claim[] claims = new[]
              {
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, RoleReferency.Names[user.Role]),
                new Claim(ClaimTypes.UserData, SerializationServ.Serialize(user))                
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
        public async void ChangeAccount(core.IUser user)
        {
            await CurrentContext.Authentication.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            SignIn(user);
        }
    }
}
