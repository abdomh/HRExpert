using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    using Abstractions;
    /// <summary>
    /// Позьователь
    /// </summary>
    [Table("Users")]
    public class User : IEntity<long>
    {
        public User()
        {
            this.Roles = new List<RoleUser>();
            this.Credentials = new List<Credential>();
        }
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
        /// <summary>
        /// Роли
        /// </summary>
        public virtual ICollection<RoleUser> Roles { get; set; }
        /// <summary>
        /// Данные для входа
        /// </summary>
        public virtual ICollection<Credential> Credentials { get; set; }
    }
}
