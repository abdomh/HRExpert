using System.Security.Claims;
using System.Linq;
using Microsoft.AspNet.Http;
using ExtCore.Data.Abstractions;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Data.Abstractions;
namespace HRExpert.Core.Services
{
    /// <summary>
    /// Сервис аутентификации
    /// </summary>
    public class AuthService: Abstractions.IAuthService
    {
        private IStorage storage;
        private IUserRepository userRepository;

        public AuthService(IStorage storage)
        {
            this.storage = storage;
            userRepository = storage.GetRepository<IUserRepository>();
        }
        /// <summary>
        /// Текущий контекст
        /// </summary>
        public HttpContext CurrentContext
        {
            get; set;
        }
        public User CurrentUser
        {
            get
            {                
                long id =long.Parse(CurrentContext.User.Claims.Where(x => x.Type == ClaimTypes.UserData)?.First()?.Value);
                return userRepository.Read(id);
            }
        }
        public void SetCurrentContext(HttpContext context)
        {
            CurrentContext = context;
        }        
    }
}
