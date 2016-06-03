using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HRExpert.Organization.Controllers
{
    using Core;    
    using DTO;
    using BL.Abstractions;
    /// <summary>
    /// Контроллер персонажей
    /// </summary>
    [Authorize]
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
        [Route(CoreConstants.Api +
            CoreConstants.version +
            OrganizationConstants.OrganizationList +
            OrganizationConstants.OrganizationKey +
            OrganizationConstants.DepartmentList +
            OrganizationConstants.DepartmentKey +
            OrganizationConstants.StaffEstablishedPostsList +
            OrganizationConstants.PositionsKey +
            OrganizationConstants.PersonList
            )
        ]
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
        [Route(CoreConstants.Api +
            CoreConstants.version +
            OrganizationConstants.OrganizationList +
            OrganizationConstants.OrganizationKey +
            OrganizationConstants.DepartmentList +
            OrganizationConstants.DepartmentKey +
            OrganizationConstants.StaffEstablishedPostsList +
            OrganizationConstants.PositionsKey +
            OrganizationConstants.PersonList +
            OrganizationConstants.PersonKey
            )
        ]
        [HttpGet]
        public PersonDto ByStaffEstablishedPostAndId(long organizationid, long departmentid, long positionid, long personid)
        {
            return personsBl.GetByStaffEstablishedPostAndId(organizationid, departmentid, positionid, personid);
        }
    }
}
