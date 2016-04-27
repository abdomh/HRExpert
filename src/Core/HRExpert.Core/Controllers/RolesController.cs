using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using HRExpert.Core.BL.Abstractions;
using HRExpert.Core.DTO;
namespace HRExpert.Core.Controllers
{
    /// <summary>
    /// Контроллер ролей(доступ только для администраторов
    /// </summary>
    [Authorize(Roles = "Администратор")]
    public class RolesController : Controller
    {
        private IRoleBL roleBl;
        #region Ctor
        public RolesController(IRoleBL roleBl)
        {
            this.roleBl = roleBl;
        }
        #endregion        
        /// <summary>
        /// Список ролей
        /// </summary>
        /// <returns>Коллекция записей</returns>
        [Route(CoreConstants.RolesController)]
        [HttpGet]
        public virtual IEnumerable<RoleDto> Get()
        {
            return roleBl.List();
        }
        /// <summary>
        /// Роль по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Роль</returns>
        [Route(CoreConstants.RolesController_key)]
        [HttpGet]
        public virtual RoleDto Get(long roleid)
        {
            return roleBl.Read(roleid);
        }
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="value">Роль</param>
        /// <returns>Роль</returns>
        [Route(CoreConstants.RolesController)]
        [HttpPost]
        public RoleDto Post([FromBody] RoleDto value)
        {
            return roleBl.Create(value);
        }
        /// <summary>
        /// Редактирование
        /// </summary>
        /// <param name="value">Роль</param>
        /// <returns>Роль</returns>
        [Route(CoreConstants.RolesController)]
        [HttpPut]
        public RoleDto Put([FromBody] RoleDto value)
        {
            return roleBl.Update(value);
        }
        /// <summary>
        /// Удаление
        /// </summary>
        [Route(CoreConstants.RolesController_key)]
        [HttpDelete]
        public RoleDto Delete(long roleid)
        {
            return roleBl.Delete(roleid);
        }
    }
}
