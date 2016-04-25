using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using HRExpert.Organization.BL.Abstractions;
using HRExpert.Organization.DTO;
namespace HRExpert.Organization.Controllers
{
    [Route(OrganizationConstants.OrganizationController)]
    [AllowAnonymous]    
    public class OrganizationController:Controller
    {
        private IOrganizationBL organizationBl;
        #region Ctor
        public OrganizationController(IOrganizationBL organizationBl)
        {
            this.organizationBl = organizationBl;
        }
        #endregion

        [HttpGet]
        [Route(OrganizationConstants.OrganizationController)]
        public virtual IEnumerable<OrganizationDto> Get()
        {
            return this.organizationBl.List();
        }
        [HttpGet]
        [Route(OrganizationConstants.OrganizationController_key)]
        public virtual OrganizationDto Get(long organizationid)
        {
            return this.organizationBl.Read(organizationid);
        }
        [HttpPost]
        [Route(OrganizationConstants.OrganizationController)]
        public virtual OrganizationDto Post([FromBody]OrganizationDto value)
        {
            return this.organizationBl.Create(value);
        }
        [HttpPut]
        [Route(OrganizationConstants.OrganizationController)]
        public virtual OrganizationDto Put([FromBody]OrganizationDto value)
        {
            return this.organizationBl.Update(value);
        }
        [HttpDelete]
        [Route(OrganizationConstants.OrganizationController_key)]
        public virtual OrganizationDto Delete(long id)
        {
            return this.organizationBl.Delete(id);
        }

    }
}
