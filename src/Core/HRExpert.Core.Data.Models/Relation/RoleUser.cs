using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    [Table("RoleUsers")]
    public class RoleUser
    {
        [Column("UserId")]
        public long UserId { get; set; }
        public User User { get; set; }
        [Column("RoleId")]
        public long RoleId { get; set; }
        public Role Role { get; set; }
    }
}
