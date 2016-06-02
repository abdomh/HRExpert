using System;

namespace HRExpert.Organization
{
    /// <summary>
    /// Событие
    /// </summary>
    public class PersonEventDto
    {
        /// <summary>
        /// Название события
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Дата начала события
        /// </summary>
        public DateTime? BeginDate { get; set; }
        /// <summary>
        /// Дата окончания события
        /// </summary>
        public DateTime? EndDate { get; set; }
    }
}
