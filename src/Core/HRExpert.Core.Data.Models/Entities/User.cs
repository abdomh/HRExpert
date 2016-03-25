﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    /// <summary>
    /// Позьователь
    /// </summary>
    [Table("Users")]
    public class User : Parent.Entity
    {
        [Column("Name")]
        public string Name { get; set; }
        public ICollection<RoleUser> Roles { get; set; }
        public ICollection<Credential> Credentials { get; set; }
    }
}