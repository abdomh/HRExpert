﻿using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    using Abstractions;
    /// <summary>
    /// Связь Роль - Пользователь
    /// </summary>
    [Table("RoleUsers")]
    public class RoleUser : IEntity
    {
        /// <summary>
        /// Идентификатор пользователя
        /// </summary>
        [ForeignKey("User")]
        public long UserId { get; set; }
        /// <summary>
        /// Пользователь
        /// </summary>
        public virtual User User { get; set; }
        /// <summary>
        /// Идентификатор роли
        /// </summary>
        [ForeignKey("Role")]
        public long RoleId { get; set; }
        /// <summary>
        /// Роль
        /// </summary>
        public virtual Role Role { get; set; }
    }
}
