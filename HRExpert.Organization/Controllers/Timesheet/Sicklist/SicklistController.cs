using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Organization.DTO;
using HRExpert.Organization.BL.Abstractions;
namespace HRExpert.Organization.Controllers.Timesheet.Sicklist
{
    public class SicklistController :Controller
    {
        ISicklistBL sicklistBL;
        public SicklistController(ISicklistBL sicklistBL)
        {
            this.sicklistBL = sicklistBL;
        }
        [HttpGet]
        [Route(Core.CoreConstants.Api + Core.CoreConstants.version + OrganizationConstants.SicklistList)]
        public List<DocumentDto<SicklistDto>> List()
        {
            return sicklistBL.List();
        }
        [Route(Core.CoreConstants.Api + Core.CoreConstants.version + OrganizationConstants.SicklistKey)]
        [HttpGet]
        public DocumentDto<SicklistDto> Read(long sicklistid)
        {
            return sicklistBL.Read(sicklistid);
        }
        [HttpPost]
        [Route(Core.CoreConstants.Api + Core.CoreConstants.version + OrganizationConstants.SicklistList)]
        public DocumentDto<SicklistDto> Create(DocumentDto<SicklistDto> dto)
        {
           return sicklistBL.Create(dto);           
        }
    }
}
