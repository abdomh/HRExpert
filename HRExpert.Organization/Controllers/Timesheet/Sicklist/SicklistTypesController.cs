using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Organization.DTO;
using HRExpert.Organization.BL.Abstractions;
namespace HRExpert.Organization.Controllers
{
    /// <summary>
    /// Типы больничных
    /// </summary>
    public class SicklistTypesController: Controller
    {
        private ISicklistTypeBL sicklistTypeBl;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sicklistTypeBl"></param>
        public SicklistTypesController(ISicklistTypeBL sicklistTypeBl)
        {
            this.sicklistTypeBl = sicklistTypeBl;
        }
        /// <summary>
        /// Список
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Core.CoreConstants.Api + Core.CoreConstants.version + OrganizationConstants.SicklistTypeList)]
        public List<SicklistTypeDto> List()
        {
            return sicklistTypeBl.List();
        }
    }
}
