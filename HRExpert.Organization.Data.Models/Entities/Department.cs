using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Organization.Data.Models
{
    [Table("Departments")]
    public class Department: Core.Data.Models.Parent.Referency
    {
        [ForeignKey("Organization")]
        public virtual long OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
    }
}
