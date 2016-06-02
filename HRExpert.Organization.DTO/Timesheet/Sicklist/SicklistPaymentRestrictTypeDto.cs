namespace HRExpert.Organization.DTO
{
    /// <summary>
    /// Тип ограничения выплат
    /// </summary>
    public class SicklistPaymentRestrictTypeDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public decimal Value { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
    }
}
