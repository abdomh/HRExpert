using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Security.Authentication.ExtendedProtection;
using System.Security.Authentication;
using Microsoft.AspNet.Authentication;
using Microsoft.AspNet.Authentication.JwtBearer;
using Microsoft.AspNet.Http.Authentication;
using AspNet.Security.OpenIdConnect.Extensions;
using AspNet.Security.OpenIdConnect.Server;
using ExtCore.Data.Abstractions;
using HRExpert.Core.Data.Abstractions;
namespace HRExpert.Core.Services
{
    public class AuthorizationProvider: OpenIdConnectServerProvider
    {
        public AuthorizationProvider(IStorage storage)
            :base()
        {
            this.SetStorage(storage);
        }
        private IStorage storage;
        private ICredentialRepository credentialRepository;
        public void SetStorage(IStorage storage)
        {
            this.storage = storage;
            this.credentialRepository = storage.GetRepository<ICredentialRepository>();
        }
        public override Task ValidateClientAuthentication(
        ValidateClientAuthenticationContext context)
        {

            ///Тут требуется коммент. Поскольку пока у нас нет мобильного приложения и других клиентов, то их идентифицировать не надо, эту фазу пропускаем (Skipped)
            context.Skipped();
            return Task.FromResult(0);
        }
       
        public override Task GrantResourceOwnerCredentials(
            GrantResourceOwnerCredentialsContext context)
        {            
            var cred = credentialRepository.GetByValueAndSecret(context.UserName, context.Password);
            if (cred == null) { context.Rejected("Пользователь не найден"); return Task.FromResult<object>(null); }
            var identity =
                new ClaimsIdentity(OpenIdConnectServerDefaults.AuthenticationScheme);
            identity.AddClaim(ClaimTypes.NameIdentifier, cred.Value);
            identity.AddClaim(ClaimTypes.UserData, cred.User.Id.ToString(), "token id_token");
            if (cred!=null && cred.User.Roles != null)
            {
                foreach (var role in cred.User.Roles)
                    identity.AddClaim(ClaimTypes.Role, role.Role.Name, "token id_token");
             }
            identity.AddClaim(ClaimTypes.Name, cred.User.Name);
            // By default, claims are not serialized in the access and identity tokens.
            // Use the overload taking a "destination" to make sure your claims
            // are correctly inserted in the appropriate tokens.
            //identity.AddClaim("urn:customclaim", "value", "token id_token");

            var ticket = new AuthenticationTicket(
                new ClaimsPrincipal(identity),
                new AuthenticationProperties(),
                context.Options.AuthenticationScheme);

            // Call SetResources with the list of resource servers
            // the access token should be issued for.
            ticket.SetResources(new[] { "resource_server_1" });            
            // Call SetScopes with the list of scopes you want to grant
            // (specify offline_access to issue a refresh token).
            ticket.SetScopes(new[] { "profile", "offline_access" });

            context.Validated(ticket);
            return Task.FromResult<object>(null);
        }
    }
}
