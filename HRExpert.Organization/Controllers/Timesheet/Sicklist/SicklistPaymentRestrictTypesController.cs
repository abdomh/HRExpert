using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Organization.DTO;
using HRExpert.Organization.BL.Abstractions;
namespace HRExpert.Organization.Controllers
{
    /// <summary>
    /// Ограничение выплат
    /// </summary>
    public class SicklistPaymentRestrictTypesController: Controller
    {
        ISicklistPaymentRestrictTypesBL sicklistPaymentRestrictTypesBL;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sicklistPaymentRestrictTypesBL"></param>
        public SicklistPaymentRestrictTypesController(ISicklistPaymentRestrictTypesBL sicklistPaymentRestrictTypesBL)
        {
            this.sicklistPaymentRestrictTypesBL = sicklistPaymentRestrictTypesBL;
        }
        /// <summary>
        /// Список
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Core.CoreConstants.Api + Core.CoreConstants.version + OrganizationConstants.SicklistPaymentRestrictTypeList)]
        public List<SicklistPaymentRestrictTypeDto> List()
        {
            return this.sicklistPaymentRestrictTypesBL.List();
        }
    }
}
