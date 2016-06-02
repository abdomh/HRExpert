using System;

namespace HRExpert.Organization.DTO
{
    /// <summary>
    /// Табель
    /// </summary>
    public class TimesheetDto
    {
        /// <summary>
        /// Событие
        /// </summary>
        public PersonEventDto Event { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public TimesheetStatusDto Status { get; set; }
    }
}
