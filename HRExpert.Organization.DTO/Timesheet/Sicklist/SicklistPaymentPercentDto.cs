namespace HRExpert.Organization.DTO
{
    /// <summary>
    /// Проценты выплат по больничным листам
    /// </summary>
    public class SicklistPaymentPercentDto
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Значение
        /// </summary>
        public decimal Value { get; set; }
    }
}
