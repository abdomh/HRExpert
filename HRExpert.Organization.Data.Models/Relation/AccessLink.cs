﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using HRExpert.Core.Data.Models;
namespace HRExpert.Organization.Data.Models
{
    [Table("AccessLinks")]
    public class AccessLink: ExtCore.Data.Models.Abstractions.IEntity
    {
        [ForeignKey("Person")]
        public long PersonId { get; set; }
        [ForeignKey("Department")]
        public long DepartmentId { get; set; }
        [ForeignKey("Role")]
        public long RoleId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Department Department { get; set; }
        public virtual Role Role { get; set; }
    }
}
