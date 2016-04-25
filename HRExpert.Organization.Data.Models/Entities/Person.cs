using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Organization.Data.Models
{
    /// <summary>
    /// Персонаж
    /// </summary>
    [Table("Persons")]
    public class Person: ExtCore.Data.Models.Abstractions.IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        [Column("Name")]
        public string Name
        {
            get; set;
        }
        /// <summary>
        /// Код
        /// </summary>
        [Column("Code")]
        public string Code
        {
            get; set;
        }
        /// <summary>
        /// Флаг удаления
        /// </summary>
        [Column("Delete")]
        public bool Delete
        {
            get; set;
        }
        /// <summary>
        /// Id подразделения
        /// </summary>
        public long DepartmentId { get; set; }
        /// <summary>
        /// Id должности
        /// </summary>
        public long PositionId { get; set; }
        /// <summary>
        /// Кол-во ставок
        /// </summary>
        public decimal PostCount { get; set; }
        /// <summary>
        /// Штатная единица
        /// </summary>
        public virtual StaffEstablishedPost StaffEstablishedPost { get; set; }
    }
}
