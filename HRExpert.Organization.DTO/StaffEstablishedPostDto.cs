namespace HRExpert.Organization.DTO
{
    /// <summary>
    /// Штатная единица
    /// </summary>
    public class StaffEstablishedPostDto
    {
        /// <summary>
        /// Подразделение
        /// </summary>
        public DepartmentDto Department {get;set;}
        /// <summary>
        /// Должность
        /// </summary>
        public PositionDto Position { get; set; }
        /// <summary>
        /// Кол-во ставок
        /// </summary>
        public decimal PostCount { get; set; }
    }
}
