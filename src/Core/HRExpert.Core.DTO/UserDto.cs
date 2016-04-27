using System;
using System.Collections.Generic;
namespace HRExpert.Core.DTO
{
    public class UserDto
    {
        public UserDto()
        {
            this.Roles = new List<RoleDto>();
        }
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }                
        /// <summary>
        /// Роли
        /// </summary>
        public List<RoleDto> Roles { get; set; }
    }
}
