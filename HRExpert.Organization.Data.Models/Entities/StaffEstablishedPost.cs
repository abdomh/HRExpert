using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace HRExpert.Organization.Data.Models
{
    [Table("StaffEstablishedPosts")]
    public class StaffEstablishedPost : ExtCore.Data.Models.Abstractions.IEntity
    {
        [ForeignKey("Department")]
        public long DepartmentId { get; set; }
        [ForeignKey("Position")]
        public long PositionId { get; set; }
        public virtual Position Position { get; set; }
        public virtual Department Department { get; set; }
        public decimal PostCount { get; set; }
        public virtual ICollection<Person> Persons { get; set; }
    }
}
