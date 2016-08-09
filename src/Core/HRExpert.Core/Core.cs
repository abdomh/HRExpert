using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HRExpert.Core.BL.Abstractions;
using HRExpert.Core.BL;
using HRExpert.Core.Services.Abstractions;
using HRExpert.Core.Services;
using ExtCore.Data.Abstractions;
using System;
using System.Collections.Generic;
using AspNet.Security.OpenIdConnect;
using AspNet.Security;
using Newtonsoft.Json.Serialization;
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
        /// Регистрация маршрутов по приоритету
        /// </summary>
        public IDictionary<int, Action<IRouteBuilder>> RouteRegistrarsByPriorities
        {
            get
            {
                return new Dictionary<int, Action<IRouteBuilder>>();
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
            services.AddScoped<IAuthService, AuthService>();
            
            services.AddAuthentication();
            services.AddMvc(/*config => config.Filters.AddService(typeof(Filters.RoleActionFilter))*/).AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver()); ;
        }
        /// <summary>
        /// Конфигурация модуля
        /// </summary>
        /// <param name="applicationBuilder"></param>
        public void Configure(IApplicationBuilder applicationBuilder)
        {
            applicationBuilder.UseWhen(context => context.Request.Path.StartsWithSegments(new PathString("/api")), branch =>
            {
                JwtBearerOptions jwtoptions = new JwtBearerOptions
                {
                    Authority = this.configurationRoot["JWT:Authority"],
                    Audience = this.configurationRoot["JWT:Audience"],
                    AutomaticAuthenticate = true,
                    AutomaticChallenge = true,
                    RequireHttpsMetadata = false
                };
                branch.UseJwtBearerAuthentication(jwtoptions);
            }
            );
            applicationBuilder.UseWhen(context => !context.Request.Path.StartsWithSegments(new PathString("/api")), branch =>
            {
                branch.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AutomaticAuthenticate = true,
                    AutomaticChallenge = true,
                    AuthenticationScheme = "ServerCookie",
                    CookieName = CookieAuthenticationDefaults.CookiePrefix + "ServerCookie",
                    ExpireTimeSpan = TimeSpan.FromMinutes(30),
                    LoginPath = new PathString("/signin"),
                    LogoutPath = new PathString("/signout")
                });
            }
            );
            applicationBuilder.UseOpenIdConnectServer(options =>
            {
                options.AllowInsecureHttp = true;
                options.AutomaticAuthenticate = true;
                options.AuthorizationEndpointPath = PathString.Empty;
                options.TokenEndpointPath = "/api/v1/connect/token";
                options.RevocationEndpointPath = "/api/v1/connect/refresh";
                options.IdentityTokenLifetime = TimeSpan.FromDays(1);
                options.AccessTokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
                options.Provider = new HRExpert.Core.Services.AuthorizationProvider(applicationBuilder.ApplicationServices.GetService<IStorage>());
            });           
        }
        /// <summary>
        /// Регистрация маршрутов
        /// </summary>
        /// <param name="routeBuilder"></param>
        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
        }
        
    }
}
