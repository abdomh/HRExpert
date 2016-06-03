using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace HRExpert
{
    public class Startup : ExtCore.WebApplication.Startup
    {
        public Startup(IHostingEnvironment hostingEnvironment)
          : base(hostingEnvironment)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
              .SetBasePath(hostingEnvironment.ContentRootPath)
              .AddJsonFile("config.json", optional: true, reloadOnChange: true)
              .AddJsonFile("appsettings.json")
              .AddJsonFile("dbconfig.json");

            this.configurationRoot = configurationBuilder.Build();
        }

        public override void ConfigureServices(IServiceCollection services)
        {           
            base.ConfigureServices(services);
        }

        public override void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment)
        {       
            if (hostingEnvironment.IsEnvironment("Development"))
            {

                applicationBuilder.UseBrowserLink();
                //applicationBuilder.UseDeveloperExceptionPage();
                //applicationBuilder.UseDatabaseErrorPage();
            }

            else
            {
                applicationBuilder.UseBrowserLink();
                //applicationBuilder.UseDeveloperExceptionPage();
                //applicationBuilder.UseDatabaseErrorPage();
            }
            applicationBuilder.UseCors(x => {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
                x.AllowCredentials();
            });
            base.Configure(applicationBuilder, hostingEnvironment);
        }
        //public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
