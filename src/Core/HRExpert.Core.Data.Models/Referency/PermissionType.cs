using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Core.Data.Models
{
    [Table("PermissionTypes")]
    public class PermissionType: Parent.Referency
    {
        [ForeignKey("Module")]
        public long ModuleId { get; set; }
        public Module Module { get; set; }
    }
}
