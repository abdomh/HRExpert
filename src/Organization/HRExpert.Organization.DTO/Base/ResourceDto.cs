using System.Collections.Generic;
namespace HRExpert.Organization.DTO
{
    /// <summary>
    /// Родительский класс для всех ресурсов
    /// </summary>
    public class ResourceDto
    {
        /// <summary>
        /// Доступность для ролей
        /// </summary>
        public List<int> AvailableForRoles { get; set; }
    }
}
