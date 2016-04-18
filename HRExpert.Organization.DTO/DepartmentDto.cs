using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Organization.DTO
{
    public class DepartmentDto: HRExpert.Core.DTO.IdNameDto
    {
        public OrganizationDto Organization { get; set; }
        public List<DepartmentDto> Childs { get; set; }
        public DepartmentDto()
        {
            this.Childs = new List<DepartmentDto>();
        }
    }
}
