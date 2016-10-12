using System.Collections.Generic;
namespace HRExpert.Organization.Data.Models
{
    public enum ApproveProgressStatusEnum
    {
        /// <summary>
        /// Не согласован
        /// </summary>
        NotApproved = 1,
        /// <summary>
        /// Согласован сотрудником
        /// </summary>
        ApprovedByEmployee = 2,
        /// <summary>
        /// Согласован руководителем
        /// </summary>
        ApprovedByManager =3,
        /// <summary>
        /// Согласован кадровиком
        /// </summary>
        ApprovedByPersonnelManager =4
    }
    public static class ApproveConstants
    {
        public static Dictionary<ApproveProgressStatusEnum, string> Names = new Dictionary<ApproveProgressStatusEnum, string>
        {
            { ApproveProgressStatusEnum.NotApproved, "Не согласован" },
            { ApproveProgressStatusEnum.ApprovedByEmployee, "Согласовано сотрудником" },
            { ApproveProgressStatusEnum.ApprovedByManager, "Согласовано руководителем" },
            { ApproveProgressStatusEnum.ApprovedByPersonnelManager, "Согласовано кадровиком" }
        };
    }
}
