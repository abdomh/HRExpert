using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Organization.DTO
{
    public class DocumentApprovementDto
    {
        public bool isAccept {get;set;}
        public int ApprovePosition { get; set; }
        public PersonDto Person { get; set; }
        public PersonDto RealPerson { get; set; }
        public DateTime? DateAccept { get; set; }
    }
}
