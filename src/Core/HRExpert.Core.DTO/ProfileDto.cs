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
        public PermissionDto[] Permissions { get; set; }        
    }
}
