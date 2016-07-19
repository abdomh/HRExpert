using AspNet.Security.OpenIdConnect.Extensions;
using AspNet.Security.OpenIdConnect.Server;
using ExtCore.Data.Abstractions;
using HRExpert.Core.Data.Abstractions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http.Authentication;
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
        public override Task ValidateTokenRequest(ValidateTokenRequestContext context)
        {
            context.Skip();
            return Task.FromResult<object>(null);
        }

        public override Task HandleTokenRequest(HandleTokenRequestContext context)
        {            
            List<string> sections = new List<string>();
            sections.Add("offline_access");
            var cred = credentialRepository.GetByValueAndSecret(context.Request.Username, context.Request.Password);
            if (cred == null) { context.Reject("Пользователь не найден"); return Task.FromResult<object>(null); }
            var identity = new ClaimsIdentity(OpenIdConnectServerDefaults.AuthenticationScheme);
            identity.AddClaim(ClaimTypes.NameIdentifier, cred.Value, OpenIdConnectConstants.Destinations.AccessToken, OpenIdConnectConstants.Destinations.IdentityToken);
            identity.AddClaim(ClaimTypes.UserData, cred.User.Id.ToString(), OpenIdConnectConstants.Destinations.AccessToken, OpenIdConnectConstants.Destinations.IdentityToken);
            if (cred != null && cred.User.Roles != null)
            {
                foreach (var role in cred.User.Roles)
                {
                    identity.AddClaim(ClaimTypes.Role, role.Role.Name, OpenIdConnectConstants.Destinations.AccessToken, OpenIdConnectConstants.Destinations.IdentityToken);
                }
            }
            identity.AddClaim(ClaimTypes.Name, cred.User.Name);
            var ticket = new AuthenticationTicket(
                new ClaimsPrincipal(identity),
                new AuthenticationProperties(),
                context.Options.AuthenticationScheme);
            ticket.Properties.AllowRefresh = true;
            ticket.SetResources(new[] { "ApiServer" });
            ticket.SetScopes(sections.Distinct().ToArray());
            context.Validate(ticket);
            return base.HandleTokenRequest(context);
        }
    }
}
