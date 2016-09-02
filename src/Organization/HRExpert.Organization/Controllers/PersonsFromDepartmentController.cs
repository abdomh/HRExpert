using Microsoft.AspNetCore.Mvc;
namespace HRExpert.Organization.Controllers
{
    using DTO;
    using BL.Abstractions;
    /// <summary>
    /// Контроллер сотрудников по ШЕ
    /// </summary>
    public class PersonsFromStaffEstablishedPostController
    {
        private IPersonBL personsBl;
        #region Ctor
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="personsBl">БЛ сотрудников</param>
        public PersonsFromStaffEstablishedPostController(IPersonBL personsBl)
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
        [HttpGet]
        public PersonDto[] PersonsList(int organizationid, int departmentid, int positionid)
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
        [HttpGet]
        public PersonDto ByStaffEstablishedPostAndId(int organizationid, int departmentid, int positionid, int personid)
        {
            return personsBl.GetByStaffEstablishedPostAndId(organizationid, departmentid, positionid, personid);
        }
    }
}
