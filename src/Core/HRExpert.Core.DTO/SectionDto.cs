using System.Collections.Generic;
namespace HRExpert.Core.DTO
{
    /// <summary>
    /// Модуль
    /// </summary>
    public class SectionDto
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
        /// Имя маршрута
        /// </summary>
        public string Route { get; set; }
        /// <summary>
        /// Права
        /// </summary>
        public List<PermissionDto> Permissions { get; set; }
    }

}
