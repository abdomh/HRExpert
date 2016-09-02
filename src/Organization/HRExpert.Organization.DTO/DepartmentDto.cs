namespace HRExpert.Organization.DTO
{
    /// <summary>
    /// Подразделение
    /// </summary>
    public class DepartmentDto: ResourceDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Идентификатор родителя
        /// </summary>
        public int ParentId { get; set; }
        /// <summary>
        /// Организация
        /// </summary>
        public OrganizationDto Organization { get; set; }        
    }
}
