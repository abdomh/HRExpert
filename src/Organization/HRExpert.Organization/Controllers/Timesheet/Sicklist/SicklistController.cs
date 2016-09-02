using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
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
        public List<DocumentDto<SicklistDto>> List()
        {
            return sicklistBL.List();
        }
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="sicklistid"></param>
        /// <returns></returns>
        [HttpGet]
        public DocumentDto<SicklistDto> Read(int sicklistid)
        {
            return sicklistBL.Read(sicklistid);
        }
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPost]        
        public DocumentDto<SicklistDto> Create([FromForm]DocumentDto<SicklistDto> value)
        {           
           return sicklistBL.Create(value);           
        }
        /// <summary>
        /// Редактирование
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        [HttpPut]
        public DocumentDto<SicklistDto> Update([FromForm]DocumentDto<SicklistDto> value)
        {
            return sicklistBL.Update(value);
        }
    }
}
