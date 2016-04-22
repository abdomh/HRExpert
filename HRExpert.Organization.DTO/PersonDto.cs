using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Organization.DTO
{
    public class PersonDto: HRExpert.Core.DTO.IdNameDto
    {
        public StaffEstablishedPostDto StaffEstablishedPost { get; set; }
        public decimal PostCount { get; set; }
    }
}
