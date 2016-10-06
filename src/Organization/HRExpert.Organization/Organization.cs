using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using HRExpert.Organization.BL;
using HRExpert.Organization.BL.Abstractions;
using System;
using System.Collections.Generic;
using Platformus.Infrastructure;
namespace HRExpert.Organization
{
    /// <summary>
    /// Startup class для модуля организация
    /// </summary>
    public class Organization : ExtensionBase, IExtension
    {
        /// <summary>
        /// Название модуля
        /// </summary>
        public new string Name
        {
            get
            {
                return "Organization";
            }
        }
        public override IEnumerable<KeyValuePair<int, Action<IServiceCollection>>> ConfigureServicesActionsByPriorities
        {
            get
            {
                return new Dictionary<int, Action<IServiceCollection>>()
                {
                    [2000] = services =>
                    {
                        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
                        services.AddScoped<IOrganizationBL, OrganizationBL>();
                        services.AddScoped<IReferenceBL, ReferenceBL>();
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
                        services.AddScoped<IMainService, MainService>();
                    }
                };
            }
        }
        public override IEnumerable<KeyValuePair<int, Action<IRouteBuilder>>> UseMvcActionsByPriorities
        {
            get
            {
                return new Dictionary<int, Action<IRouteBuilder>>()
                {
                    [1000] = routeBuilder =>
                    {
                        routeBuilder.MapRoute(name: "Organizations", template: "{culture=ru}/{controller=Home}/{action=Index}/{Id?}");
                    }
                };
            }
        }
        public override IEnumerable<KeyValuePair<int, Action<IApplicationBuilder>>> ConfigureActionsByPriorities
        {
            get
            {
                return new Dictionary<int, Action<IApplicationBuilder>>()
                {
                   
                };
            }
        }

    }
}
