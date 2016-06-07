using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Organization.DTO;
using HRExpert.Organization.BL.Abstractions;

namespace HRExpert.Organization.Controllers
{

    public class TimesheetStatusController: Controller
    {
        ITimesheetStatusBL timesheetStatusBl;
        public TimesheetStatusController(ITimesheetStatusBL timesheetStatusBl)
        {
            this.timesheetStatusBl = timesheetStatusBl;
        }
        [Route(Core.CoreConstants.Api+Core.CoreConstants.version + OrganizationConstants.TimesheetStatusList)]
        [HttpGet]
        public List<TimesheetStatusDto> List()
        {
            return timesheetStatusBl.List();
        }
    }
}
