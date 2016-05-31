using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
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
        [Route(CoreConstants.PermissionsController)]
        [HttpGet]
        public virtual IEnumerable<PermissionDto> Get()
        {
            return permissionBl.List();
        }
        /// <summary>
        /// Права по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор</param>
        /// <returns>Права</returns>
        [Route(CoreConstants.PermissionsController_key)]
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
        [Route(CoreConstants.PermissionsController)]
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
        [Route(CoreConstants.PermissionsController)]
        [HttpPut]
        public PermissionDto Put([FromBody] PermissionDto value)
        {
            return permissionBl.Update(value);
        }
        /// <summary>
        /// Удаление
        /// </summary>
        [Route(CoreConstants.PermissionsController_key)]
        [HttpDelete]
        public PermissionDto Delete(long permissionid)
        {
            return permissionBl.Delete(permissionid);
        }
    }
}
