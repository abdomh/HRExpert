﻿using Microsoft.AspNetCore.Builder;
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
        private string GetXmlCommentsPath(string subproject)
        {
            var app = PlatformServices.Default.Application;
            return System.IO.Path.Combine(app.ApplicationBasePath, System.IO.Path.ChangeExtension(app.ApplicationName+ (subproject.Length>0?"."+subproject:""), "xml"));
        }
        public override void ConfigureServices(IServiceCollection services)
        {
            string pathToDoc = hostingEnvironment.ContentRootPath;
            services.AddSwaggerGen();
            services.ConfigureSwaggerGen(options => {
                options.DescribeAllEnumsAsStrings();
                options.IncludeXmlComments(GetXmlCommentsPath(string.Empty));
                options.IncludeXmlComments(GetXmlCommentsPath("Core"));
                options.IncludeXmlComments(GetXmlCommentsPath("Organization"));
                options.SingleApiVersion(new Swashbuckle.SwaggerGen.Generator.Info
                {
                    Version = "v1",
                    Title = "HRExpert API",
                    Description = "HREXpert API",
                    TermsOfService = "None"                    
                });
            });
            
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
