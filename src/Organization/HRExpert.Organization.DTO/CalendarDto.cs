using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Organization.DTO
{
    public class CalendarDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
}
