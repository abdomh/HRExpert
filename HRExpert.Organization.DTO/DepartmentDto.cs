using System.Collections.Generic;

namespace HRExpert.Organization.DTO
{
    /// <summary>
    /// Подразделение
    /// </summary>
    public class DepartmentDto
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
        /// Идентификатор родителя
        /// </summary>
        public long ParentId { get; set; }
        /// <summary>
        /// Организация
        /// </summary>
        public OrganizationDto Organization { get; set; }
        
    }
}
