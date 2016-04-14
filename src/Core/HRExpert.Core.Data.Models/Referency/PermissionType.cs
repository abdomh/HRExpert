using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Core.Data.Models
{
    [Table("PermissionTypes")]
    public class PermissionType: Parent.Referency
    {
        [ForeignKey("Section")]
        public long SectionId { get; set; }
        public Section Section { get; set; }
    }
}
