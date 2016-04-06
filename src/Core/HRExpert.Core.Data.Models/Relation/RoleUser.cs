using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    [Table("RoleUsers")]
    public class RoleUser
    {
        [ForeignKey("User")]
        public long UserId { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("Role")]
        public long RoleId { get; set; }
        public virtual Role Role { get; set; }
    }
}
