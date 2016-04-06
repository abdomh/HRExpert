﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    [Table("Roles")]
    public class Role: Parent.Referency
    {
        public virtual ICollection<RoleUser> Users { get; set; }
    }
}
