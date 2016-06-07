using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Organization.DTO;
using HRExpert.Organization.BL.Abstractions;
namespace HRExpert.Organization.Controllers
{
    public class SicklistPaymentRestrictTypesController: Controller
    {
        ISicklistPaymentRestrictTypesBL sicklistPaymentRestrictTypesBL;
        public SicklistPaymentRestrictTypesController(ISicklistPaymentRestrictTypesBL sicklistPaymentRestrictTypesBL)
        {
            this.sicklistPaymentRestrictTypesBL = sicklistPaymentRestrictTypesBL;
        }
        [HttpGet]
        [Route(Core.CoreConstants.Api + Core.CoreConstants.version + OrganizationConstants.SicklistPaymentRestrictTypeList)]
        public List<SicklistPaymentRestrictTypeDto> List()
        {
            return this.sicklistPaymentRestrictTypesBL.List();
        }
    }
}
