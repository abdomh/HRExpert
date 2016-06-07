using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Organization.DTO;
using HRExpert.Organization.BL.Abstractions;
namespace HRExpert.Organization.Controllers
{
    public class SicklistPaymentPercentController: Controller
    {
        ISicklistPaymentPercentBL sicklistPaymentPercentBL;
        public SicklistPaymentPercentController(ISicklistPaymentPercentBL sicklistPaymentPercentBL)
        {
            this.sicklistPaymentPercentBL = sicklistPaymentPercentBL;
        }
        [HttpGet]
        [Route(Core.CoreConstants.Api + Core.CoreConstants.version + OrganizationConstants.SicklistPaymentPercentList)]
        public List<SicklistPaymentPercentDto> List()
        {
            return this.sicklistPaymentPercentBL.List();
        }
    }
}
