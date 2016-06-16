using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HRExpert.Organization.BL;
using HRExpert.Organization.BL.Abstractions;
namespace HRExpert.Organization
{
    /// <summary>
    /// Startup class для модуля организация
    /// </summary>
    public class Organization : ExtCore.Infrastructure.IExtension
    {
        private IConfigurationRoot configurationRoot;
        /// <summary>
        /// Название модуля
        /// </summary>
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
        /// <summary>
        /// Регистрация сервисов
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IFileBl, FileBl>();
            services.AddScoped<IOrganizationBL, OrganizationBL>();            
            services.AddScoped<IDepartmentBL, DepartmentBL>();
            services.AddScoped<IPositionsBL, PositionsBL>();
            services.AddScoped<IPersonBL, PersonsBL>();
            services.AddScoped<IStaffEstablishedPostBL, StaffEstablishedPostBL>();
            services.AddScoped<ITimesheetStatusBL, TimesheetStatusBL>();
            services.AddScoped<ISicklistBabyMindingTypesBL, SicklistBabyMindingTypesBL>();
            services.AddScoped<ISicklistBL, SicklistBL>();
            services.AddScoped<ISicklistPaymentPercentBL, SicklistPaymentPercentBL>();
            services.AddScoped<ISicklistPaymentRestrictTypesBL, SicklistPaymentRestrictTypesBL>();
            services.AddScoped<ISicklistTypeBL, SicklistTypeBL>();            
        }
        /// <summary>
        /// Конфигурация
        /// </summary>
        /// <param name="applicationBuilder"></param>
        public void Configure(IApplicationBuilder applicationBuilder)
        {            
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
