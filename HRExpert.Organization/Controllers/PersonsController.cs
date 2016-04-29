using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using HRExpert.Organization.BL.Abstractions;
using HRExpert.Core.Controllers;
using HRExpert.Organization.DTO;
using HRExpert.Core.DTO;
namespace HRExpert.Organization.Controllers
{
    /// <summary>
    /// Контроллер персонажей
    /// </summary>
    [Route(OrganizationConstants.PersonsController)]
    public class PersonsController : Controller
    {
        private IPersonBL personsBl;
        #region Ctor
        public PersonsController(IPersonBL personsBl)
        {
            this.personsBl = personsBl;
        }

        #endregion        
        /// <summary>
        /// Список персонажей по штатной единице
        /// </summary>
        /// <param name="organizationid">Идентификатор организации</param>
        /// <param name="departmentid">Идентификатор подразделения</param>
        /// <param name="positionid">Идентификатор должности</param>
        /// <returns></returns>
        [Route(OrganizationConstants.PersonsControllerPath)]
        [HttpGet]
        public PersonDto[] PersonsList(long organizationid,long departmentid,long positionid)
        {
            return personsBl.GetByStaffEstablishedPost(organizationid, departmentid, positionid).ToArray();
        }
        /// <summary>
        /// Персонаж по штатной единице и идентификатору
        /// </summary>
        /// <param name="organizationid">организация</param>
        /// <param name="departmentid">подразделение</param>
        /// <param name="positionid">должность</param>
        /// <param name="personid">идентификатор</param>
        /// <returns></returns>
        [Route(OrganizationConstants.PersonsControllerPath_key)]
        [HttpGet]
        public PersonDto ByStaffEstablishedPostAndId(long organizationid, long departmentid, long positionid, long personid)
        {
            return personsBl.GetByStaffEstablishedPostAndId(organizationid, departmentid, positionid, personid);
        }
    }
}
