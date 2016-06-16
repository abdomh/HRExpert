using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Organization.DTO;
using HRExpert.Organization.BL.Abstractions;
namespace HRExpert.Organization.Controllers.Timesheet.Sicklist
{
    /// <summary>
    /// Контроллер получения ключей доступа к файлу больничных
    /// </summary>
    public class SicklistFilesController
    {
        ISicklistBL sicklistBl;
        public SicklistFilesController(ISicklistBL sicklistBl)
        {
            this.sicklistBl = sicklistBl;
        }
        /// <summary>
        /// Получение ключа для загруки файла
        /// </summary>
        /// <param name="sicklistid"></param>
        /// <param name="filetypeid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(Core.CoreConstants.Api+Core.CoreConstants.version + OrganizationConstants.SicklistList + OrganizationConstants.SicklistKey+"/files/{filetypeid}")]
        public Guid Index(long sicklistid, int filetypeid)
        {
            return this.sicklistBl.GetFileKey(sicklistid, filetypeid);
        }
    }
}
