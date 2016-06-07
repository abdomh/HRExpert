using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Organization.DTO;
using HRExpert.Organization.BL.Abstractions;
namespace HRExpert.Organization.Controllers.Timesheet.Sicklist
{
    /// <summary>
    /// Типы больничных по уходу за ребенком
    /// </summary>
    public class SicklistBabyMindingTypesController: Controller
    {
        ISicklistBabyMindingTypesBL sicklistBabyMindingTypesBL;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sicklistBabyMindingTypesBL"></param>
        public SicklistBabyMindingTypesController( ISicklistBabyMindingTypesBL sicklistBabyMindingTypesBL)
        {
            this.sicklistBabyMindingTypesBL = sicklistBabyMindingTypesBL;
        }
        /// <summary>
        /// Список записей
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Core.CoreConstants.Api + Core.CoreConstants.version + OrganizationConstants.SicklistBabyMindingTypeList)]
        
        public List<SicklistBabyMindingTypeDto> List()
        {
            return this.sicklistBabyMindingTypesBL.List();
        }
    }
}
