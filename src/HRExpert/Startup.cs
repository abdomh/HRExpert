using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Swashbuckle.SwaggerGen;
using Swashbuckle.SwaggerUi;
using Swashbuckle;
namespace HRExpert
{
    public class Startup : ExtCore.WebApplication.Startup
    {
        IHostingEnvironment hostingEnvironment;
        public Startup(IHostingEnvironment hostingEnvironment)
          : base(hostingEnvironment)
        {
            this.hostingEnvironment = hostingEnvironment;
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
              .SetBasePath(hostingEnvironment.ContentRootPath)
              .AddJsonFile("config.json", optional: true, reloadOnChange: true)
              .AddJsonFile("appsettings.json")
              .AddJsonFile("dbconfig.json");

            this.configurationRoot = configurationBuilder.Build();
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            string pathToDoc = hostingEnvironment.ContentRootPath;
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options => {

                options.DescribeAllEnumsAsStrings();
               
                options.SingleApiVersion(new Swashbuckle.SwaggerGen.Generator.Info
                {
                    Version = "v1",
                    Title = "HRExpert API",
                    Description = "HREXpert API",
                    TermsOfService = "None"
                });
            });
            //services.ConfigureSwaggerDocument(options =>
            //{
                
            //    //options.OperationFilter(new Swashbuckle.SwaggerGen.XmlComments.ApplyXmlActionComments(pathToDoc));
            //});

            //services.ConfigureSwaggerSchema(options =>
            //{
            //    options.DescribeAllEnumsAsStrings = true;
            //    //options.ModelFilter(new Swashbuckle.SwaggerGen.XmlComments.ApplyXmlTypeComments(pathToDoc));
            //});
            base.ConfigureServices(services);
        }

        public override void Configure(IApplicationBuilder applicationBuilder, IHostingEnvironment hostingEnvironment)
        {       
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
            
            applicationBuilder.UseCors(x => {
                x.AllowAnyOrigin();
                x.AllowAnyMethod();
                x.AllowAnyHeader();
                x.AllowCredentials();
            });
            base.Configure(applicationBuilder, hostingEnvironment);

            applicationBuilder.UseSwaggerGen();
            applicationBuilder.UseSwaggerUi();
        }
        //public static void Main(string[] args) => WebApplication.Run<Startup>(args);
    }
}
