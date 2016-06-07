using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Organization.DTO;
using HRExpert.Organization.BL.Abstractions;
namespace HRExpert.Organization.Controllers
{
    public class SicklistTypesController: Controller
    {
        private ISicklistTypeBL sicklistTypeBl;
        public SicklistTypesController(ISicklistTypeBL sicklistTypeBl)
        {
            this.sicklistTypeBl = sicklistTypeBl;
        }
        [HttpGet]
        [Route(Core.CoreConstants.Api + Core.CoreConstants.version + OrganizationConstants.SicklistTypeList)]
        public List<SicklistTypeDto> List()
        {
            return sicklistTypeBl.List();
        }
    }
}
