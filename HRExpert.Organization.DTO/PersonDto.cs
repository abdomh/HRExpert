namespace HRExpert.Organization.DTO
{
    /// <summary>
    /// Персонаж
    /// </summary>
    public class PersonDto
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
        /// Штатная единица
        /// </summary>
        public StaffEstablishedPostDto StaffEstablishedPost { get; set; }    
        /// <summary>
        /// Кол-во ставок
        /// </summary>
        public decimal PostCount { get; set; }
    }
}
