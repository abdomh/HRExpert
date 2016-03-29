using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Authentication.JwtBearer;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Filters;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HRExpert.Core.BL.Abstractions;
using HRExpert.Core.BL;
using HRExpert.Core.Services.Abstractions;
using HRExpert.Core.Services;

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
            services.AddSingleton<IBaseBL, BaseBL>();
            services.AddSingleton<IAccountBL, AccountBL>();
            services.AddSingleton<IUsersBL, UsersBL>();
            services.AddSingleton<IRoleBL, RolesBL>();
            services.AddSingleton<IAuthService, AuthService>();
            services.AddSingleton<ISerializationService, SerializationService>();

            services.AddAuthentication();
            services.AddCaching();
        }

        public void Configure(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseCors(x=> {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
            });
            applicationBuilder.Use( (context, next) => {
                IAuthService authService = context.ApplicationServices.GetService<IAuthService>();
                authService.SetCurrentContext(context);
                return next.Invoke();
            });
            /*
            applicationBuilder.UseCookieAuthentication(options => {
                options.AuthenticationScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.AutomaticAuthenticate = true;
                options.AutomaticChallenge = true;
                options.CookieName = "HRExpert";
                options.ExpireTimeSpan = new System.TimeSpan(1, 0, 0);
                options.LoginPath = new PathString("/account/signin");
            });
            */
            // Add a new middleware validating access tokens issued by the server.
            applicationBuilder.UseJwtBearerAuthentication(options =>
            {
                options.AutomaticAuthenticate = true;
                options.AutomaticChallenge = true;                
                options.Audience = "resource_server_1";
                options.Authority = "http://localhost:5000/";
                options.RequireHttpsMetadata = false;
            });

            // Add a new middleware issuing tokens.
            applicationBuilder.UseOpenIdConnectServer(options =>
            {
                options.AllowInsecureHttp = true;
                options.AuthorizationEndpointPath = PathString.Empty;
                options.TokenEndpointPath = "/connect/token";
                options.Provider = new HRExpert.Core.Services.AuthorizationProvider();
            });
        }

        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            //routeBuilder.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
