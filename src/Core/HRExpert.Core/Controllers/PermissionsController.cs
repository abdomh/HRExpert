using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Core.BL.Abstractions;
using HRExpert.Core.DTO;

namespace HRExpert.Core.Controllers.api
{
    /// <summary>
    /// Контроллер прав
    /// (доступ только для администраторов)
    /// </summary>
    //[Authorize(Roles = "Администратор")]
    [AllowAnonymous]
    public class PermissionsController: Controller
    {
        private IPermissionBL permissionBl;
        #region Ctor
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="permissionBl"></param>
        public PermissionsController(IPermissionBL permissionBl)
        {
            this.permissionBl = permissionBl;
        }
        #endregion
        /// <summary>
        /// Список прав
        /// </summary>
        /// <returns>Коллекция записей</returns>
        [Route(CoreConstants.Api + CoreConstants.version + CoreConstants.PermissionsList)]
        [HttpGet]
        public virtual IEnumerable<PermissionDto> Get()
        {
            return permissionBl.List();
        }
        /// <summary>
        /// Права по идентификатору
        /// </summary>
        /// <param name="permissionid">Идентификатор</param>
        /// <returns>Права</returns>
        [Route(CoreConstants.Api + CoreConstants.version + CoreConstants.PermissionsList+ CoreConstants.PermissionKey)]
        [HttpGet]
        public virtual PermissionDto Get(long permissionid)
        {
            return permissionBl.Read(permissionid);
        }
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="value">Права</param>
        /// <returns>Права</returns>
        [Route(CoreConstants.Api + CoreConstants.version + CoreConstants.PermissionsList)]
        [HttpPost]
        public PermissionDto Post([FromBody] PermissionDto value)
        {
            return permissionBl.Create(value);
        }
        /// <summary>
        /// Редактирование
        /// </summary>
        /// <param name="value">Права</param>
        /// <returns>Права</returns>
        [Route(CoreConstants.Api + CoreConstants.version + CoreConstants.PermissionsList)]
        [HttpPut]
        public PermissionDto Put([FromBody] PermissionDto value)
        {
            return permissionBl.Update(value);
        }
        /// <summary>
        /// Удаление
        /// </summary>
        [Route(CoreConstants.Api + CoreConstants.version + CoreConstants.PermissionsList + CoreConstants.PermissionKey)]
        [HttpDelete]
        public PermissionDto Delete(long permissionid)
        {
            return permissionBl.Delete(permissionid);
        }
    }
}
