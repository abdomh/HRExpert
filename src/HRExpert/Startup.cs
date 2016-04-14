using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;

namespace HRExpert
{
    public class Startup : ExtCore.WebApplication.Startup
    {
        public Startup(IHostingEnvironment hostingEnvironment, IApplicationEnvironment applicationEnvironment, IAssemblyLoaderContainer assemblyLoaderContainer, IAssemblyLoadContextAccessor assemblyLoadContextAccessor, ILibraryManager libraryManager)
          : base(hostingEnvironment, applicationEnvironment, assemblyLoaderContainer, assemblyLoadContextAccessor, libraryManager)
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
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
            applicationBuilder.UseIISPlatformHandler();
            if (hostingEnvironment.IsEnvironment("Development"))
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
            
            base.Configure(applicationBuilder, hostingEnvironment);
        }
        public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
