using System;
using Microsoft.AspNetCore.Mvc;
using HRExpert.Organization.BL.Abstractions;
namespace HRExpert.Organization.Controllers.Timesheet.Sicklist
{
    /// <summary>
    /// Контроллер получения ключей доступа к файлу больничных
    /// </summary>
    public class SicklistFilesController
    {
        ISicklistBL sicklistBl;
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sicklistBl">БЛ больничных</param>
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
        public Guid Index(int sicklistid, int filetypeid)
        {
            return this.sicklistBl.GetFileKey(sicklistid, filetypeid);
        }
    }
}
