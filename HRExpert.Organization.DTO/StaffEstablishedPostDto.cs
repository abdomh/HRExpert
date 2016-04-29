namespace HRExpert.Organization.DTO
{
    /// <summary>
    /// Штатная единица
    /// </summary>
    public class StaffEstablishedPostDto
    {
        /// <summary>
        /// Идентификатор организации
        /// </summary>
        public long OrganizationId { get; set; }
        /// <summary>
        /// Идентификатор подразделения
        /// </summary>
        public long DepartmentId { get; set; }
        /// <summary>
        /// Идентификатор должности
        /// </summary>
        public long PositionId { get; set; }        
        /// <summary>
        /// Кол-во ставок
        /// </summary>
        public decimal PostCount { get; set; }
    }
}
