using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    [Table("RolePermissionTypes")]
    public class RolePermission
    {
        [Column("RoleId")]
        public long RoleId { get; set; }
        [Column("PermissionTypeId")]
        public long PermissionTypeId { get; set; }
        public virtual Role Role { get; set; }
        public virtual PermissionType PermissionType { get; set; }
    }
}
