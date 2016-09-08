using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Mvc.Razor;
namespace HRExpert
{
    /// <summary>
    ///  Startup
    /// </summary>
    public class Startup : Platformus.WebApplication.Startup
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="serviceProvider">сервис провайдер</param>
        public Startup(IServiceProvider serviceProvider)
          : base(serviceProvider)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
              .SetBasePath(this.serviceProvider.GetService<IHostingEnvironment>().ContentRootPath)
              .AddJsonFile("appsettings.json")
              .AddJsonFile("dbconfig.json");

            this.configurationRoot = configurationBuilder.Build();
            
        }
        private string GetXmlCommentsPath(string subproject)
        {
            var app = PlatformServices.Default.Application;
            return System.IO.Path.Combine(app.ApplicationBasePath, System.IO.Path.ChangeExtension(app.ApplicationName+ (subproject.Length>0?"."+subproject:""), "xml"));
        }
        /// <summary>
        /// Конфигурация сервисов
        /// </summary>
        /// <param name="services">коллекция сервисов</param>
        public override void ConfigureServices(IServiceCollection services)
        {           
            base.ConfigureServices(services);
            services.Configure<RazorViewEngineOptions>(options =>
            {
                options.ViewLocationExpanders.Add(new ThemeLocationExpander(this.configurationRoot));
            }
            );
        }
        /// <summary>
        /// Конфигурация
        /// </summary>
        /// <param name="applicationBuilder">билдер</param>
        public override void Configure(IApplicationBuilder applicationBuilder)
        {       
            if (this.serviceProvider.GetService<IHostingEnvironment>().IsEnvironment("Development"))
            {
                
                applicationBuilder.UseBrowserLink();                
                applicationBuilder.UseDeveloperExceptionPage();
                applicationBuilder.UseDatabaseErrorPage();
            }

            else
            {
                applicationBuilder.UseBrowserLink();
                applicationBuilder.UseDeveloperExceptionPage();
                applicationBuilder.UseDatabaseErrorPage();
            }
            
            applicationBuilder.UseCors(x => {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
                x.AllowCredentials();
            });
            base.Configure(applicationBuilder);            
        }
    }
}
