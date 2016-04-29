namespace HRExpert.Organization.DTO
{
    /// <summary>
    /// Персонаж
    /// </summary>
    public class PersonDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
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
