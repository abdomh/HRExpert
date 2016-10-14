using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Organization.DTO
{
    public class CalendarDto
    {
        public CalendarDto()
        {
            allDay = true;
        }
        public string id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
        public bool allDay { get; set; }
        public string borderColor { get; set; }
        public string backgroundColor { get; set; }
    }
}
