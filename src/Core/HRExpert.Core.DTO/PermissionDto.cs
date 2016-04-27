namespace HRExpert.Core.DTO
{
    /// <summary>
    /// Права
    /// </summary>
    public class PermissionDto 
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
        /// Модуль
        /// </summary>
        public long SectionId { get; set; }
        /// <summary>
        /// Модуль
        /// </summary>
        public SectionDto Section { get; set; }
    }
}
