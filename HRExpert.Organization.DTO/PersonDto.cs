namespace HRExpert.Organization.DTO
{
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
        public StaffEstablishedPostDto StaffEstablishedPost { get; set; }
        public decimal PostCount { get; set; }
    }
}
