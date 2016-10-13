using System.Collections.Generic;

namespace HRExpert.Organization.Data.Models
{
    public enum PermissionCodeEnum
    {
        /// <summary>
        /// Редактирование заявки сотрудником
        /// </summary>
        Request_Edit_Employee,
        /// <summary>
        /// Редактирование заявки руководителем
        /// </summary>
        Request_Edit_Manager,
        /// <summary>
        /// Редактирование заявки кадровиком
        /// </summary>
        Request_Edit_PersonnelManager
    }
    public static class PermissionsCodeConstants
    {
        public const string Request_Edit_Employee = "Request.Edit.Employee";
        public const string Request_Edit_Manager = "Request.Edit.Manager";
        public const string Request_Edit_PersonnelManager = "Request.Edit.PersonnelManager";

        public static Dictionary<PermissionCodeEnum, string> Codes = new Dictionary<PermissionCodeEnum, string> {
            {PermissionCodeEnum.Request_Edit_Employee, Request_Edit_Employee },
            {PermissionCodeEnum.Request_Edit_Manager, Request_Edit_Manager },
            {PermissionCodeEnum.Request_Edit_PersonnelManager, Request_Edit_PersonnelManager }
        };
    }
}
