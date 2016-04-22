using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Filters;
using Microsoft.AspNet.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HRExpert.Organization.BL;
using HRExpert.Organization.BL.Abstractions;
namespace HRExpert.Organization
{
    public class Organization : ExtCore.Infrastructure.IExtension
    {
        private IConfigurationRoot configurationRoot;

        public string Name
        {
            get
            {
                return "Organization";
            }
        }


        public void SetConfigurationRoot(IConfigurationRoot configurationRoot)
        {
            this.configurationRoot = configurationRoot;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IOrganizationBL, OrganizationBL>();
            services.AddScoped<IDepartmentBL, DepartmentBL>();
            services.AddScoped<IPositionsBL, PositionsBL>();
            services.AddScoped<IPersonBL, PersonsBL>();
            services.AddScoped<IStaffEstablishedPostBL, StaffEstablishedPostBL>();
        }

        public void Configure(IApplicationBuilder applicationBuilder)
        {
            
        }

        public void RegisterRoutes(IRouteBuilder routeBuilder)
        {
        }
    }
}
