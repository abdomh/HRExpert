using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Platformus.Security;

namespace HRExpert.Organization
{
    public class OrganizationAuthPolicy : IAuthorizationPolicyRegistrar
    {
        public void RegisterAuthorizationPolicy(AuthorizationPolicyBuilder authorizationPolicyBuilder)
        {
            authorizationPolicyBuilder.RequireAssertion(
              handler =>
              {
                  AuthorizationFilterContext authorizationFilterContext = handler.Resource as AuthorizationFilterContext;
                  string controller = (string)authorizationFilterContext.RouteData.Values["controller"];
                  return !(controller.ToLower() == "sicklist") || authorizationFilterContext.HttpContext.User.Identity.IsAuthenticated;
              }
            );
        }
    }
}
