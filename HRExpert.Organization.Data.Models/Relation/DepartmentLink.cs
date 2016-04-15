using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Organization.Data.Models
{
    [Table("DepartmentLinks")]
    public class DepartmentLink
    {
        [ForeignKey("Left")]
        public virtual long LeftId { get; set; }
        [ForeignKey("Right")]
        public virtual long RightId { get; set; }
        public virtual Department Left { get; set; }
        public virtual Department Right { get; set; }
    }
}
