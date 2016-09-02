using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HRExpert.Organization.Controllers
{
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
        /// <summary>
        /// Конструктор контроллера сотрудников
        /// </summary>
        /// <param name="personsBl">БЛ сотрудников</param>
        public PersonsController(IPersonBL personsBl)
        {
            this.personsBl = personsBl;
        }

        #endregion        
        /// <summary>
        /// Список персонажей по штатной единице
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public PersonDto[] PersonsList()
        {
            return personsBl.List().ToArray();
        }
        /// <summary>
        /// Список персонажей по штатной единице
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public PersonDto Read(int personid)
        {
            return personsBl.Read(personid);
        }

    }
}
