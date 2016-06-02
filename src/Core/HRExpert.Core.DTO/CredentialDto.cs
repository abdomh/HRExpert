namespace HRExpert.Core.DTO
{
    /// <summary>
    /// Учётные данный
    /// </summary>
    public class CredentialDto
    {
        /// <summary>
        /// Логин
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Пароль
        /// </summary>
        public string Secret { get; set; }
        /// <summary>
        /// Тип учётных данных
        /// </summary>
        public CredentialTypeDto Type { get; set;}
    }
}
