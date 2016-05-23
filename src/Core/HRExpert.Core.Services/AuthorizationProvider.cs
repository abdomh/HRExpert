using AspNet.Security.OpenIdConnect.Extensions;
using AspNet.Security.OpenIdConnect.Server;
using ExtCore.Data.Abstractions;
using HRExpert.Core.Data.Abstractions;
using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Http.Authentication;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
namespace HRExpert.Core.Services
{
    /// <summary>
    /// Провайдер авторизации
    /// </summary>
    public class AuthorizationProvider: OpenIdConnectServerProvider
    {
        private IStorage storage;
        private ICredentialRepository credentialRepository;

        public AuthorizationProvider(IStorage storage)
            :base()
        {
            this.SetStorage(storage);
        }
        /// <summary>
        /// Установка хранилища
        /// </summary>
        /// <param name="storage"></param>
        public void SetStorage(IStorage storage)
        {
            this.storage = storage;
            this.credentialRepository = storage.GetRepository<ICredentialRepository>();
        }
        /// <summary>
        /// Проверка аутентификации клиента
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task ValidateClientAuthentication(ValidateClientAuthenticationContext context)
        {
            ///Тут требуется коммент. Поскольку пока у нас нет мобильного приложения и других клиентов, то их идентифицировать не надо, эту фазу пропускаем (Skipped)
            context.Skipped();
            return Task.FromResult(0);
        }
        /// <summary>
        /// Создание токена
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override Task GrantResourceOwnerCredentials(GrantResourceOwnerCredentialsContext context)
        {
            List<string> sections = new List<string>();
            sections.Add("offline_access");
            var cred = credentialRepository.GetByValueAndSecret(context.UserName, context.Password);
            if (cred == null) { context.Rejected("Пользователь не найден"); return Task.FromResult<object>(null); }
            var identity = new ClaimsIdentity(OpenIdConnectServerDefaults.AuthenticationScheme);
            identity.AddClaim(ClaimTypes.NameIdentifier, cred.Value);
            identity.AddClaim(ClaimTypes.UserData, cred.User.Id.ToString(), "token id_token");            
            if (cred!=null && cred.User.Roles != null)
            {
                foreach (var role in cred.User.Roles)
                {
                    identity.AddClaim(ClaimTypes.Role, role.Role.Name, "token id_token");                    
                }
             }
            identity.AddClaim(ClaimTypes.Name, cred.User.Name);
            var ticket = new AuthenticationTicket(
                new ClaimsPrincipal(identity),
                new AuthenticationProperties(),
                context.Options.AuthenticationScheme);            
            ticket.SetResources(new[] { "ApiServer" });            
            ticket.SetScopes(sections.Distinct().ToArray());
            context.Validated(ticket);
            return Task.FromResult<object>(null);
        }
    }
}
