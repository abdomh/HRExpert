using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    [Table("Roles")]
    public class Role: Parent.Referency
    {
        public Role()
        {
            this.Users = new List<RoleUser>();
            this.Permissions = new List<RolePermission>();
        }
        public virtual ICollection<RoleUser> Users { get; set; }
        public virtual ICollection<RolePermission> Permissions { get; set; }
    }
}
