using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Organization.Data.Models
{
    [Table("Persons")]
    public class Person : Core.Data.Models.Parent.Referency
    {
        public long DepartmentId { get; set; }
        public long PositionId { get; set; }
        public decimal PostCount { get; set; }
        public virtual StaffEstablishedPost StaffEstablishedPost { get; set; }
    }
}
