using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HRExpert.Organization.Controllers
{
    using DTO;
    using BL.Abstractions;
    /// <summary>
    /// Контроллер организаций
    /// </summary>
    //[Authorize]
    [AllowAnonymous]
    public class OrganizationController:Controller
    {        
        private IOrganizationBL organizationBl;
        #region Ctor
        /// <summary>
        /// Конструктор организации
        /// </summary>
        /// <param name="organizationBl">БЛ организации</param>
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
        public virtual OrganizationDto Get(int organizationid)
        {
            return this.organizationBl.Read(organizationid);
        }
        /// <summary>
        /// Создание организации
        /// </summary>
        /// <param name="value">Организация</param>
        /// <returns></returns>
        [HttpPost]
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
        public virtual OrganizationDto Put([FromBody]OrganizationDto value)
        {
            return this.organizationBl.Update(value);
        }
        /// <summary>
        /// Удаление организации
        /// </summary>
        /// <param name="organizationid">Идентификатор организации</param>
        /// <returns>Организация</returns>
        [HttpDelete]
        public virtual OrganizationDto Delete(int organizationid)
        {
            return this.organizationBl.Delete(organizationid);
        }

    }
}
