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
        /// Организация
        /// </summary>
        public OrganizationDto Organization { get; set; }
        /// <summary>
        /// Дочерние подразделения
        /// </summary>
        public List<DepartmentDto> Childs { get; set; }
        public DepartmentDto()
        {
            this.Childs = new List<DepartmentDto>();
        }
    }
}
