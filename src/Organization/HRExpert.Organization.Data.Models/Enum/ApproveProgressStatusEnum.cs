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
        public const string NotApproved = "Не согласован";
        public const string ApprovedByEmployee = "Согласовано сотрудником";
        public const string ApprovedByManager = "Согласовано руководителем";
        public const string ApprovedByPersonnelManager = "Согласовано кадровиком";

        public static Dictionary<ApproveProgressStatusEnum, string> Names = new Dictionary<ApproveProgressStatusEnum, string>
        {
            { ApproveProgressStatusEnum.NotApproved, NotApproved },
            { ApproveProgressStatusEnum.ApprovedByEmployee, ApprovedByEmployee },
            { ApproveProgressStatusEnum.ApprovedByManager, ApprovedByManager },
            { ApproveProgressStatusEnum.ApprovedByPersonnelManager, ApprovedByPersonnelManager }
        };
    }
}
