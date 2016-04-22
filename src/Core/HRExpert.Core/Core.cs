using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Authentication.JwtBearer;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Filters;
using Microsoft.AspNet.Cors;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HRExpert.Core.BL.Abstractions;
using HRExpert.Core.BL;
using HRExpert.Core.Services.Abstractions;
using HRExpert.Core.Services;
using ExtCore.Data.Abstractions;
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
            services.AddScoped<IBaseBL, BaseBL>();
            services.AddScoped<IUsersBL, UsersBL>();
            services.AddScoped<IRoleBL, RolesBL>();
            services.AddScoped<ISectionBL, SectionsBL>();
            services.AddScoped<IPermissionBL, PermissionsBL>();

            services.AddScoped<IAuthService, AuthService>();
            
            services.AddAuthentication();
            services.AddCaching();
        }

        public void Configure(IApplicationBuilder applicationBuilder)
        {           
            
            applicationBuilder.UseJwtBearerAuthentication(options =>
            {
                string authority = this.configurationRoot["JWT:Authority"];
                string audience = this.configurationRoot["JWT:Audience"];
                options.AutomaticAuthenticate = true;
                options.AutomaticChallenge = true;
                options.Audience = audience;
                options.Authority = authority;
                options.RequireHttpsMetadata = false;
            });

            // Add a new middleware issuing tokens.
            applicationBuilder.UseOpenIdConnectServer(options =>
            {
                options.AllowInsecureHttp = true;
                options.AutomaticAuthenticate = true;
                options.AuthorizationEndpointPath = PathString.Empty;
                options.TokenEndpointPath = "/connect/token";
                options.Provider = new HRExpert.Core.Services.AuthorizationProvider(applicationBuilder.ApplicationServices.GetService<IStorage>());
            });
            applicationBuilder.Use( (context, next) => {
                //IAuthService authService = context.ApplicationServices.GetService<IAuthService>();
                //authService.SetCurrentContext(context);
                return next.Invoke();
            });          
            
        }

        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
            //routeBuilder.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
