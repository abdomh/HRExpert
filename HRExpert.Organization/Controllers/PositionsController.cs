using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using HRExpert.Organization.BL.Abstractions;
using HRExpert.Organization.DTO;

namespace HRExpert.Organization.Controllers
{
    /// <summary>
    /// Контроллер должностей
    /// </summary>
    [AllowAnonymous]
    public class PositionsController : Controller
    {
        private IPositionsBL positionsBl;
        #region Ctor
        public PositionsController(IPositionsBL positionsBl)            
        {
            this.positionsBl = positionsBl;
        }
        #endregion
        /// <summary>
        /// Список должностей
        /// </summary>
        /// <returns>Коллекция записей</returns>
        [HttpGet]
        [Route(OrganizationConstants.PositionsController)]
        public virtual IEnumerable<PositionDto> Get()
        {
            return this.positionsBl.List();
        }
        /// <summary>
        /// Должность по идентификатору
        /// </summary>
        /// <param name="positionid"></param>
        /// <returns></returns>
        [HttpGet]
        [Route(OrganizationConstants.PositionsController_key)]
        public virtual PositionDto Get(long positionid)
        {
            return this.positionsBl.Read(positionid);
        }
        /// <summary>
        /// Создание должности
        /// </summary>
        /// <param name="value">Должность</param>
        /// <returns></returns>
        [HttpPost]
        [Route(OrganizationConstants.PositionsController)]
        public virtual PositionDto Post([FromBody]PositionDto value)
        {
            return this.positionsBl.Create(value);
        }
        /// <summary>
        /// Редактирование должности
        /// </summary>
        /// <param name="value">должность</param>
        /// <returns>должность</returns>
        [HttpPut]
        [Route(OrganizationConstants.PositionsController)]
        public virtual PositionDto Put([FromBody]PositionDto value)
        {
            return this.positionsBl.Update(value);
        }
        /// <summary>
        /// Удаление должности
        /// </summary>
        /// <param name="positionid">Идентификатор должности</param>
        /// <returns></returns>
        [HttpDelete]
        [Route(OrganizationConstants.PositionsController_key)]
        public virtual PositionDto Delete(long positionid)
        {
            return this.positionsBl.Delete(positionid);
        }
    }
}
