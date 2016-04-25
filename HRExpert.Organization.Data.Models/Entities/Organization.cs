using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Organization.Data.Models
{
    /// <summary>
    /// Организация
    /// </summary>
    [Table("Organizations")]
    public class Organization: ExtCore.Data.Models.Abstractions.IEntity
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
        /// Подразделения
        /// </summary>
        public virtual ICollection<Department> Departments { get; set; }
    }
}
