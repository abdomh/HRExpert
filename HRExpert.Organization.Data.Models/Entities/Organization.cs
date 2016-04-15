using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Organization.Data.Models
{
    [Table("Organizations")]
    public class Organization: Core.Data.Models.Parent.Referency
    {
        public virtual ICollection<Department> Departments { get; set; }
    }
}
