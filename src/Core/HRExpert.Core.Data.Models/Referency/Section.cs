using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    [Table("Sections")]
    public class Section: Parent.Referency
    {
        public virtual ICollection<PermissionType> Permissions { get; set; }
    }
}
