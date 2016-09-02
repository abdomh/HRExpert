using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Organization.Data.Models
{
    /// <summary>
    /// Организация
    /// </summary>
    [Table("Organizations")]
    public class Organization: Abstractions.IEntity<int>
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        [Column("Name")]
        public string Name
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
