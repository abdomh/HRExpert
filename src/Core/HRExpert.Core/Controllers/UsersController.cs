using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Core.BL.Abstractions;
using HRExpert.Core.DTO;

namespace HRExpert.Core.Controllers.api
{
    /// <summary>
    /// Контроллер пользователей (Доступ только для администраторов)
    /// </summary>
    [Authorize(Roles = "Администратор")]
    public class UsersController : Controller
    {
        private IUsersBL userBl;
        #region Ctor
        public UsersController(IUsersBL userBl)
        {
            this.userBl = userBl;
        }
        #endregion
        /// <summary>
        /// Список пользователей
        /// </summary>
        /// <returns>Коллекция записей</returns>
        [Route(CoreConstants.UsersController)]
        [HttpGet]
        public virtual IEnumerable<UserDto> Get()
        {
            return userBl.List();
        }
        /// <summary>
        /// Пользователь по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Пользователь</returns>
        [Route(CoreConstants.UsersController_key)]
        [HttpGet]
        public virtual UserDto Get(long userid)
        {
            return userBl.Read(userid);
        }
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="value">Пользователь</param>
        /// <returns>Пользователь</returns>
        [Route(CoreConstants.UsersController)]
        [HttpPost]
        public UserDto Post([FromBody] UserDto value)
        {
            return userBl.Create(value);
        }
        /// <summary>
        /// Редактирование
        /// </summary>
        /// <param name="value">Пользователь</param>
        /// <returns>Пользователь</returns>
        [Route(CoreConstants.UsersController)]
        [HttpPut]
        public UserDto Put([FromBody] UserDto value)
        {
            return userBl.Update(value);
        }
        /// <summary>
        /// Удаление
        /// </summary>
        [Route(CoreConstants.UsersController_key)]
        [HttpDelete]
        public UserDto Delete(long userid)
        {
            return userBl.Delete(userid);
        }
    }
}
