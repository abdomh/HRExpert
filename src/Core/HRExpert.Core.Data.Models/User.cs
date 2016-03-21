using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRExpert.Core.Data.Models.Abstractions;

namespace HRExpert.Core.Data.Models
{    
    /// <summary>
    /// Позьователь
    /// </summary>
    public class User: Parent.Entity, IUser
    {
        /// <summary>
        /// Пароль
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
    }
}
