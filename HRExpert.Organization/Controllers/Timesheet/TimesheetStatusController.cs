using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Organization.DTO;
using HRExpert.Organization.BL.Abstractions;

namespace HRExpert.Organization.Controllers
{
    /// <summary>
    /// Контроллер табеля
    /// </summary>
    public class TimesheetStatusController: Controller
    {
        ITimesheetStatusBL timesheetStatusBl;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="timesheetStatusBl">БЛ табеля</param>
        public TimesheetStatusController(ITimesheetStatusBL timesheetStatusBl)
        {
            this.timesheetStatusBl = timesheetStatusBl;
        }
        /// <summary>
        /// Список
        /// </summary>
        /// <returns>коллекция значений табеля</returns>
        [Route(Core.CoreConstants.Api+Core.CoreConstants.version + OrganizationConstants.TimesheetStatusList)]
        [HttpGet]
        public List<TimesheetStatusDto> List()
        {
            return timesheetStatusBl.List();
        }
    }
}
