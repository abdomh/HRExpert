using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Organization.Data.Models
{
    /// <summary>
    /// Должность
    /// </summary>
    [Table("Positions")]
    public class Position: Abstractions.IEntity<int>
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
    }
}
