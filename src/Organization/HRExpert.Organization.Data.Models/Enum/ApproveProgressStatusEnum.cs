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
}
