using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
namespace HRExpert.Organization.Controllers
{
    using DTO;
    using BL.Abstractions;
    using Core;
    /// <summary>
    /// Штатные единицы
    /// </summary>
    [Authorize]
    public class StaffEstablishedPostsController:Controller
    {
        private IStaffEstablishedPostBL staffEstablishedPostBl;
        #region Ctor
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="staffEstablishedPostBl"></param>
        public StaffEstablishedPostsController(IStaffEstablishedPostBL staffEstablishedPostBl)            
        {
            this.staffEstablishedPostBl = staffEstablishedPostBl;
        }
        #endregion     
        /// <summary>
        /// Список по подразделению
        /// </summary>
        /// <param name="departmentid">Идентификатор подразделения</param>         
        [Route(CoreConstants.Api +
            CoreConstants.version +
            OrganizationConstants.OrganizationList +
            OrganizationConstants.OrganizationKey +
            OrganizationConstants.DepartmentList +
            OrganizationConstants.DepartmentKey +
            OrganizationConstants.StaffEstablishedPostsList
            )
        ]        
        [HttpGet]                
        public StaffEstablishedPostDto[] List(long departmentid)
        {
            return this.staffEstablishedPostBl.GetByDepartment(departmentid)?.ToArray();
        }
        /// <summary>
        /// Чтение по идентификтору подразделения и должности
        /// </summary>
        /// <param name="departmentid">Подразделение</param>
        /// <param name="positionid">Должность</param>
        /// <returns></returns>
        [Route(CoreConstants.Api +
            CoreConstants.version +
            OrganizationConstants.OrganizationList +
            OrganizationConstants.OrganizationKey +
            OrganizationConstants.DepartmentList +
            OrganizationConstants.DepartmentKey +
            OrganizationConstants.StaffEstablishedPostsList +
            OrganizationConstants.PositionsKey
            )
        ]
        [HttpGet]
        public StaffEstablishedPostDto Read(long departmentid, long positionid)
        {
            return this.staffEstablishedPostBl.GetByDepartmentAndPosition(departmentid, positionid);
        }
    }
}
