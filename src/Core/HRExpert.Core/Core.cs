using System.Collections.Generic;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Filters;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Security.Cryptography;
using Microsoft.AspNet.Authentication.Cookies;
namespace HRExpert.Core
{
    public class Core : ExtCore.Infrastructure.IExtension
    {
        private IConfigurationRoot configurationRoot;

        public string Name
        {
            get
            {
                return "Core";
            }
        }
        

        public void SetConfigurationRoot(IConfigurationRoot configurationRoot)
        {
            this.configurationRoot = configurationRoot;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MvcOptions>(options =>
            {
                //options.Filters.Add(new AuthorizeFilter(new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build()));
            }
            );
        }

        public void Configure(IApplicationBuilder applicationBuilder)
        {            
            applicationBuilder.UseCookieAuthentication(options => {
                options.AuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.AutomaticAuthenticate = true;
                options.AutomaticChallenge = true;
                options.CookieName = "HRExpert";
                options.ExpireTimeSpan = new System.TimeSpan(1, 0, 0);
                options.LoginPath = new PathString("/account/signin");
            });
        }

        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            routeBuilder.MapRoute("default", "{controller=Account}/{action=Index}/{id?}");
        }
    }
}
