using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Core.Data.Models
{
    using Abstractions;
    /// <summary>
    /// Права
    /// </summary>
    [Table("PermissionTypes")]
    public class PermissionType: IEntity<long>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Column("Id")]
        [Key]
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
        public string Code { get; set; }
        /// <summary>
        /// Флаг удаления
        /// </summary>
        [Column("Delete")]
        public bool Delete
        {
            get; set;
        }
        /// <summary>
        /// Идентификатор модуля
        /// </summary>
        [ForeignKey("Section")]
        public long SectionId { get; set; }
        /// <summary>
        /// Модуль
        /// </summary>
        public Section Section { get; set; }
    }
}
