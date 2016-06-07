using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Core.BL.Abstractions;
using HRExpert.Core.DTO;
namespace HRExpert.Core.Controllers
{
    /// <summary>
    /// Контроллер ролей
    /// </summary>
    
    public class RolesController : Controller
    {
        private IRoleBL roleBl;
        #region Ctor
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="roleBl"></param>
        public RolesController(IRoleBL roleBl)
        {
            this.roleBl = roleBl;
        }
        #endregion        
        /// <summary>
        /// Список ролей
        /// </summary>
        /// <returns>Коллекция записей</returns>
        [Authorize]
        [Route(CoreConstants.Api + CoreConstants.version + CoreConstants.RolesList)]
        [HttpGet]
        public virtual IEnumerable<RoleDto> Get()
        {
            return roleBl.List();
        }
        /// <summary>
        /// Роль по идентификатору
        /// </summary>
        /// <param name="roleid">Идентификатор</param>
        /// <returns>Роль</returns>
        [Authorize]
        [Route(CoreConstants.Api + CoreConstants.version + CoreConstants.RolesList + CoreConstants.RoleKey)]
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
        [Authorize(Roles = "Администратор")]
        [Route(CoreConstants.Api + CoreConstants.version + CoreConstants.RolesList)]
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
        [Authorize(Roles = "Администратор")]
        [Route(CoreConstants.Api + CoreConstants.version + CoreConstants.RolesList)]
        [HttpPut]
        public RoleDto Put([FromBody] RoleDto value)
        {
            return roleBl.Update(value);
        }
        /// <summary>
        /// Удаление
        /// </summary>
        [Authorize(Roles = "Администратор")]
        [Route(CoreConstants.Api + CoreConstants.version + CoreConstants.RolesList+ CoreConstants.RoleKey)]
        [HttpDelete]
        public RoleDto Delete(long roleid)
        {
            return roleBl.Delete(roleid);
        }

       
    }
}
