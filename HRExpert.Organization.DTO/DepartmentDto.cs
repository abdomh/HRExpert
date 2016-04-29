using System.Collections.Generic;

namespace HRExpert.Organization.DTO
{
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
        /// Идентификатор организации
        /// </summary>
        public long OrganizationId { get; set; }
        
        public DepartmentDto()
        {
        }
    }
}
