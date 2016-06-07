using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Organization.DTO;
using HRExpert.Organization.BL.Abstractions;
namespace HRExpert.Organization.Controllers
{
    /// <summary>
    /// Контроллер процентов выплат
    /// </summary>
    public class SicklistPaymentPercentController: Controller
    {
        ISicklistPaymentPercentBL sicklistPaymentPercentBL;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sicklistPaymentPercentBL"></param>
        public SicklistPaymentPercentController(ISicklistPaymentPercentBL sicklistPaymentPercentBL)
        {
            this.sicklistPaymentPercentBL = sicklistPaymentPercentBL;
        }
        /// <summary>
        /// Список
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Core.CoreConstants.Api + Core.CoreConstants.version + OrganizationConstants.SicklistPaymentPercentList)]
        public List<SicklistPaymentPercentDto> List()
        {
            return this.sicklistPaymentPercentBL.List();
        }
    }
}
