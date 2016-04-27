using System.Collections.Generic;

namespace HRExpert.Core.DTO
{
    /// <summary>
    /// Роль
    /// </summary>
    public class RoleDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Права
        /// </summary>
        public List<PermissionDto> Permissions { get; set; }
    }
}
