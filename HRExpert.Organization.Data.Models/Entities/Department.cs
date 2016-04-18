using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Organization.Data.Models
{
    [Table("Departments")]
    public class Department: Core.Data.Models.Parent.Referency
    {
        public Department()
        {
            this.Right = new List<DepartmentLink>();
            this.Left = new List<DepartmentLink>();
        }
        [ForeignKey("Organization")]
        public virtual long OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual ICollection<DepartmentLink> Left { get; set; }
        public virtual ICollection<DepartmentLink> Right { get; set; }
    }
}
