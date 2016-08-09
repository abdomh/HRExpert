using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Organization.Data.Models
{
    using Core.Data.Models.Abstractions;
    /// <summary>
    /// Штатная единица
    /// </summary>
    [Table("StaffEstablishedPosts")]
    public class StaffEstablishedPost : IEntity
    {
        /// <summary>
        /// Id подразделения
        /// </summary>
        [ForeignKey("Department")]
        public long DepartmentId { get; set; }
        /// <summary>
        /// Id должности
        /// </summary>
        [ForeignKey("Position")]
        public long PositionId { get; set; }
        /// <summary>
        /// Должность
        /// </summary>
        public virtual Position Position { get; set; }
        /// <summary>
        /// Подразделение
        /// </summary>
        public virtual Department Department { get; set; }
        /// <summary>
        /// Кол-во ставок
        /// </summary>
        public decimal PostCount { get; set; }
        /// <summary>
        /// Персонажи
        /// </summary>
        public virtual ICollection<Person> Persons { get; set; }
    }
}
