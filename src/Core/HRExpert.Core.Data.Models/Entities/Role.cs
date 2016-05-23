using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Core.Data.Models
{
    /// <summary>
    /// Роль
    /// </summary>
    [Table("Roles")]
    public class Role: ExtCore.Data.Models.Abstractions.IEntity
    {
        public Role()
        {
            this.Users = new List<RoleUser>();
            this.Permissions = new List<RolePermission>();
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
        /// Пользователи
        /// </summary>
        public virtual ICollection<RoleUser> Users { get; set; }
        /// <summary>
        /// Права
        /// </summary>
        public virtual ICollection<RolePermission> Permissions { get; set; }
        /// <summary>
        /// Модули
        /// </summary>
        public virtual ICollection<RoleSection> Sections { get; set; }
    }
}
