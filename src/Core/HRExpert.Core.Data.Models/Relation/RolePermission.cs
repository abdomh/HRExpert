using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    /// <summary>
    /// Связь Роль - Права
    /// </summary>
    [Table("RolePermissionTypes")]
    public class RolePermission
    {
        /// <summary>
        /// Идентификатор роли
        /// </summary>
        [Column("RoleId")]
        public long RoleId { get; set; }
        /// <summary>
        /// Идентификатор прав
        /// </summary>
        [Column("PermissionTypeId")]
        public long PermissionTypeId { get; set; }
        /// <summary>
        /// Роль
        /// </summary>
        public virtual Role Role { get; set; }
        /// <summary>
        /// Права
        /// </summary>
        public virtual PermissionType PermissionType { get; set; }
    }
}
