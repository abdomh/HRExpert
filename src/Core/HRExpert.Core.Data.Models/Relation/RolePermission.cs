using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    [Table("RolePermissions")]
    public class RolePermission
    {
        [Column("RoleId")]
        public long RoleId { get; set; }
        [Column("PermissionTypeId")]
        public long PermissionTypeId { get; set; }
        public Role Role { get; set; }
        public PermissionType PermissionType { get; set; }
    }
}
