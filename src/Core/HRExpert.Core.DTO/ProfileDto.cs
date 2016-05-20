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
        /// Роли
        /// </summary>
        public List<RoleDto> Roles { get; set; }

    }
}
