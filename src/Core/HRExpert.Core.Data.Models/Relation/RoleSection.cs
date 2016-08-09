using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    using Abstractions;
    [Table("RoleSections")]
    public class RoleSection: IEntity
    {
        [ForeignKey("Role")]
        public long RoleId { get; set; }
        [ForeignKey("Section")]
        public long SectionId { get; set; }
        public virtual Role Role { get; set; }
        public virtual Section Section { get; set; }
    }
}
