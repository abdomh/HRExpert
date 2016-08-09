using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    using Abstractions;
    /// <summary>
    /// Типы данных для входа
    /// </summary>
    [Table("CredentialTypes")]
    public class CredentialType: IEntity<long>
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
        /// Флаг удаления
        /// </summary>
        [Column("Delete")]
        public bool Delete
        {
            get; set;
        }
    }
}
