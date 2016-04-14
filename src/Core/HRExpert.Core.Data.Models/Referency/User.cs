using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    /// <summary>
    /// Позьователь
    /// </summary>
    [Table("Users")]
    public class User : Parent.Referency
    {
        public User()
        {
            this.Roles = new List<RoleUser>();
            this.Credentials = new List<Credential>();
        }       
        public virtual ICollection<RoleUser> Roles { get; set; }
        public virtual ICollection<Credential> Credentials { get; set; }
    }
}
