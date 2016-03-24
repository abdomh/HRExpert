using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    /// <summary>
    /// Позьователь
    /// </summary>
    [Table("Users")]
    public class User : Parent.EntityWithObject
    {
        /// <summary>
        /// Пароль
        /// </summary>
        [Column("Password")]
        public string Password { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Column("Email")]
        public string Email { get; set; }

        public ICollection<RoleUsers> Roles { get; set; }
        
    }
}
