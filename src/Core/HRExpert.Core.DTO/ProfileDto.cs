using System.Collections.Generic;
namespace HRExpert.Core.DTO
{
    /// <summary>
    /// Профиль
    /// </summary>
    public class ProfileDto
    {
        /// <summary>
        /// ФИО
        /// </summary>
        public string UserName { get; set; }
        
        /// <summary>
        /// Права
        /// </summary>
        public List<PermissionDto> Permissions { get; set; }
        /// <summary>
        /// Меню
        /// </summary>
        public List<SectionDto> Sections { get; set; }

    }
}
