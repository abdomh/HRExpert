using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Organization.DTO;
using HRExpert.Organization.BL.Abstractions;
namespace HRExpert.Organization.Controllers.Timesheet.Sicklist
{
    public class SicklistBabyMindingTypesController: Controller
    {
        ISicklistBabyMindingTypesBL sicklistBabyMindingTypesBL;
        public SicklistBabyMindingTypesController( ISicklistBabyMindingTypesBL sicklistBabyMindingTypesBL)
        {
            this.sicklistBabyMindingTypesBL = sicklistBabyMindingTypesBL;
        }
        [HttpGet]
        [Route(Core.CoreConstants.Api + Core.CoreConstants.version + OrganizationConstants.SicklistBabyMindingTypeList)]
        public List<SicklistBabyMindingTypeDto> List()
        {
            return this.sicklistBabyMindingTypesBL.List();
        }
    }
}
