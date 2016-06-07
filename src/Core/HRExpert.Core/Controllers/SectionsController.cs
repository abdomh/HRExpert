using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Core.BL.Abstractions;
using HRExpert.Core.DTO;

namespace HRExpert.Core.Controllers
{
    /// <summary>
    /// Контроллер модулей (Доступ только для администратора)
    /// </summary>
    [Authorize(Roles = "Администратор")]
    public class SectionsController : Controller
    {
        private ISectionBL sectionBl;
        #region Ctor
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sectionBl"></param>
        public SectionsController(ISectionBL sectionBl)
        {
            this.sectionBl = sectionBl;
        }
        #endregion
        /// <summary>
        /// Список Модулей
        /// </summary>
        /// <returns>Коллекция записей</returns>
        [Route(CoreConstants.Api + CoreConstants.version + CoreConstants.SectionsList)]
        [HttpGet]
        public virtual IEnumerable<SectionDto> Get()
        {
            return sectionBl.List();
        }
        /// <summary>
        /// Модуль по идентификатору
        /// </summary>
        /// <param name="sectionid">Идентификатор</param>
        /// <returns>Модуль</returns>
        [Route(CoreConstants.Api + CoreConstants.version + CoreConstants.SectionsList + CoreConstants.SectionKey)]
        [HttpGet]
        public virtual SectionDto Get(long sectionid)
        {
            return sectionBl.Read(sectionid);
        }
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="value">Модуль</param>
        /// <returns>Модуль</returns>
        [Route(CoreConstants.Api + CoreConstants.version + CoreConstants.SectionsList)]
        [HttpPost]
        public SectionDto Post([FromBody] SectionDto value)
        {
            return sectionBl.Create(value);
        }
        /// <summary>
        /// Редактирование
        /// </summary>
        /// <param name="value">Модуль</param>
        /// <returns>Модуль</returns>
        [Route(CoreConstants.Api + CoreConstants.version + CoreConstants.SectionsList)]
        [HttpPut]
        public SectionDto Put([FromBody] SectionDto value)
        {
            return sectionBl.Update(value);
        }
        /// <summary>
        /// Удаление
        /// </summary>
        [Route(CoreConstants.Api + CoreConstants.version + CoreConstants.SectionsList + CoreConstants.SectionKey)]
        [HttpDelete]
        public SectionDto Delete(long sectionid)
        {
            return sectionBl.Delete(sectionid);
        }
    }
}
