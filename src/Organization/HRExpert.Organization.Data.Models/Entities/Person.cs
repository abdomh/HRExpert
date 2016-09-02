using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    /// <summary>
    /// Персонаж
    /// </summary>
    [Table("Persons")]
    public class Person: Abstractions.IEntity<int>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        [Column("Name")]
        public string Name
        {
            get; set;
        }
       
        
        /// <summary>
        /// Id подразделения
        /// </summary>
        public int? DepartmentId { get; set; }
        /// <summary>
        /// Id должности
        /// </summary>
        public int? PositionId { get; set; }
        /// <summary>
        /// Кол-во ставок
        /// </summary>
        public decimal? PostCount { get; set; }
        /// <summary>
        /// Штатная единица
        /// </summary>
        public virtual StaffEstablishedPost StaffEstablishedPost { get; set; }
        public virtual ICollection<AccessLink> AccessLinks { get; set; }
    }
}
