using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using HRExpert.Organization.BL.Abstractions;
using HRExpert.Organization.DTO;
namespace HRExpert.Organization.Controllers
{
    /// <summary>
    /// Контроллер организаций
    /// </summary>
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
        /// <summary>
        /// Список организаций
        /// </summary>
        /// <returns>Коллекция записей</returns>
        [HttpGet]
        [Route(OrganizationConstants.OrganizationController)]
        public virtual IEnumerable<OrganizationDto> Get()
        {
            return this.organizationBl.List();
        }
        /// <summary>
        /// Организация по идентификатору
        /// </summary>
        /// <param name="organizationid">Идентификатор</param>
        /// <returns></returns>
        [HttpGet]
        [Route(OrganizationConstants.OrganizationController_key)]
        public virtual OrganizationDto Get(long organizationid)
        {
            return this.organizationBl.Read(organizationid);
        }
        /// <summary>
        /// Создание организации
        /// </summary>
        /// <param name="value">Организация</param>
        /// <returns></returns>
        [HttpPost]
        [Route(OrganizationConstants.OrganizationController)]
        public virtual OrganizationDto Post([FromBody]OrganizationDto value)
        {
            return this.organizationBl.Create(value);
        }
        /// <summary>
        /// Редактирование организации
        /// </summary>
        /// <param name="value">Организация</param>
        /// <returns></returns>
        [HttpPut]
        [Route(OrganizationConstants.OrganizationController)]
        public virtual OrganizationDto Put([FromBody]OrganizationDto value)
        {
            return this.organizationBl.Update(value);
        }
        /// <summary>
        /// Удаление организации
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Route(OrganizationConstants.OrganizationController_key)]
        public virtual OrganizationDto Delete(long id)
        {
            return this.organizationBl.Delete(id);
        }

    }
}
