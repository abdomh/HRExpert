using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HRExpert.Core.BL.Abstractions;
using HRExpert.Core.BL;
using HRExpert.Core.Services.Abstractions;
using HRExpert.Core.Services;
using ExtCore.Data.Abstractions;
using System;

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
        /// <summary>
        /// Установка конфига
        /// </summary>
        /// <param name="configurationRoot"></param>
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
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUsersBL, UsersBL>();
            services.AddScoped<IRoleBL, RolesBL>();
            services.AddScoped<ISectionBL, SectionsBL>();
            services.AddScoped<IPermissionBL, PermissionsBL>();
            services.AddScoped<Filters.RoleActionFilter>();
            services.AddScoped<IAuthService, AuthService>();
            
            services.AddAuthentication();
            services.AddMvc(/*config => config.Filters.AddService(typeof(Filters.RoleActionFilter))*/);
        }
        /// <summary>
        /// Конфигурация модуля
        /// </summary>
        /// <param name="applicationBuilder"></param>
        public void Configure(IApplicationBuilder applicationBuilder)
        {
            JwtBearerOptions jwtoptions = new JwtBearerOptions {
               Authority = this.configurationRoot["JWT:Authority"],
               Audience = this.configurationRoot["JWT:Audience"],
               AutomaticAuthenticate = true,
               AutomaticChallenge = true,
               RequireHttpsMetadata = false
            };
            applicationBuilder.UseJwtBearerAuthentication(jwtoptions);
           
            applicationBuilder.UseOpenIdConnectServer(options =>
            {
                options.AllowInsecureHttp = true;
                options.AutomaticAuthenticate = true;
                options.AuthorizationEndpointPath = PathString.Empty;
                options.TokenEndpointPath = "/connect/token";
                options.UseJwtTokens();
                options.Provider = new HRExpert.Core.Services.AuthorizationProvider(applicationBuilder.ApplicationServices.GetService<IStorage>());
            });           
        }

        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
        }
        
    }
}
