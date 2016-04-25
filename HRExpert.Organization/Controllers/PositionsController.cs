using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using HRExpert.Organization.BL.Abstractions;
using HRExpert.Organization.DTO;

namespace HRExpert.Organization.Controllers
{
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
        [HttpGet]
        [Route(OrganizationConstants.PositionsController)]
        public virtual IEnumerable<PositionDto> Get()
        {
            return this.positionsBl.List();
        }
        [HttpGet]
        [Route(OrganizationConstants.PositionsController_key)]
        public virtual PositionDto Get(long positionid)
        {
            return this.positionsBl.Read(positionid);
        }
        [HttpPost]
        [Route(OrganizationConstants.PositionsController)]
        public virtual PositionDto Post([FromBody]PositionDto value)
        {
            return this.positionsBl.Create(value);
        }
        [HttpPut]
        [Route(OrganizationConstants.PositionsController)]
        public virtual PositionDto Put([FromBody]PositionDto value)
        {
            return this.positionsBl.Update(value);
        }
        [HttpDelete]
        [Route(OrganizationConstants.PositionsController_key)]
        public virtual PositionDto Delete(long positionid)
        {
            return this.positionsBl.Delete(positionid);
        }
    }
}
