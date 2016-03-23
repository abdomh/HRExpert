﻿using System.ComponentModel.DataAnnotations.Schema;
using HRExpert.Core.Data.Models.Abstractions;

namespace HRExpert.Core.Data.Models
{    
    /// <summary>
    /// Позьователь
    /// </summary>
    [Table("Users")]
    public class User: Parent.EntityWithObject, IUser
    {
        /// <summary>
        /// Пароль
        /// </summary>
        [Column("Password")]
        public string Password { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        [Column("Email")]
        public string Email { get; set; }        
    }
}
