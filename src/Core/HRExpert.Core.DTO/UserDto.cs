using System.Collections.Generic;
namespace HRExpert.Core.DTO
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class UserDto
    {
        public UserDto()
        {
            this.Roles = new List<RoleDto>();
            this.Credentials = new List<CredentialDto>();
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
        /// <summary>
        /// Учётные данные
        /// </summary>
        public List<CredentialDto> Credentials { get; set; }
    }
}
