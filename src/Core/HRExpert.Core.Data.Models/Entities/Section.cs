using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    using Abstractions;
    /// <summary>
    /// Модуль
    /// </summary>
    [Table("Sections")]
    public class Section: IEntity<long>
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
        /// Имя маршрута
        /// </summary>
        public string RouteName { get; set; }
        /// <summary>
        /// Флаг удаления
        /// </summary>
        [Column("Delete")]
        public bool Delete
        {
            get; set;
        }
        public virtual ICollection<PermissionType> Sections { get; set; }
    }
}
