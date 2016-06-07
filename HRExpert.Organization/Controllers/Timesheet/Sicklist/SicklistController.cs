using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Organization.DTO;
using HRExpert.Organization.BL.Abstractions;
namespace HRExpert.Organization.Controllers.Timesheet.Sicklist
{
    /// <summary>
    /// Контроллер больничных
    /// </summary>
    public class SicklistController :Controller
    {
        ISicklistBL sicklistBL;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sicklistBL"></param>
        public SicklistController(ISicklistBL sicklistBL)
        {
            this.sicklistBL = sicklistBL;
        }
        /// <summary>
        /// Список
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route(Core.CoreConstants.Api + Core.CoreConstants.version + OrganizationConstants.SicklistList)]
        public List<DocumentDto<SicklistDto>> List()
        {
            return sicklistBL.List();
        }
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="sicklistid"></param>
        /// <returns></returns>
        [Route(Core.CoreConstants.Api + Core.CoreConstants.version + OrganizationConstants.SicklistKey)]
        [HttpGet]
        public DocumentDto<SicklistDto> Read(long sicklistid)
        {
            return sicklistBL.Read(sicklistid);
        }
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(Core.CoreConstants.Api + Core.CoreConstants.version + OrganizationConstants.SicklistList)]        
        public DocumentDto<SicklistDto> Create(DocumentDto<SicklistDto> dto)
        {
           return sicklistBL.Create(dto);           
        }
    }
}
