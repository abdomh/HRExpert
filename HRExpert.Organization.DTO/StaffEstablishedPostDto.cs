using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Organization.DTO
{
    public class StaffEstablishedPostDto
    {
        public PositionDto Position {get;set;}
        public DepartmentDto Department { get; set; }
        public List<PersonDto> Persons { get; set; }
        public decimal PostCount { get; set; }
    }
}
