using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
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
    /// <summary>
    /// Startup class для модуля ядра
    /// </summary>
    public class Core : ExtCore.Infrastructure.IExtension
    {
        private IConfigurationRoot configurationRoot;
        /// <summary>
        /// Имя модуля
        /// </summary>
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
        /// <summary>
        /// Регистрация сервисов
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IUsersBL, UsersBL>();
            services.AddScoped<IRoleBL, RolesBL>();
            services.AddScoped<ISectionBL, SectionsBL>();
            services.AddScoped<IPermissionBL, PermissionsBL>();
            services.AddScoped<Filters.RoleActionFilter>();
            services.AddScoped<IAuthService, AuthService>();
            
            services.AddAuthentication();
            services.AddCaching();
            services.AddMvc(config => config.Filters.AddService(typeof(Filters.RoleActionFilter)));
        }
        /// <summary>
        /// Конфигурация модуля
        /// </summary>
        /// <param name="applicationBuilder"></param>
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
            
            applicationBuilder.UseOpenIdConnectServer(options =>
            {
                options.AllowInsecureHttp = true;
                options.AutomaticAuthenticate = true;
                options.AuthorizationEndpointPath = PathString.Empty;
                options.TokenEndpointPath = "/connect/token";
                options.Provider = new HRExpert.Core.Services.AuthorizationProvider(applicationBuilder.ApplicationServices.GetService<IStorage>());
            });           
        }

        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
        }
    }
}
