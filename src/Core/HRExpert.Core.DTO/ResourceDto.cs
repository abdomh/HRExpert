using System.Collections.Generic;
namespace HRExpert.Core.DTO
{
    /// <summary>
    /// Родительский класс для всех ресурсов
    /// </summary>
    public class ResourceDto
    {
        /// <summary>
        /// Доступность для ролей
        /// </summary>
        public List<RoleDto> AvailableForRoles { get; set; }
    }
}
