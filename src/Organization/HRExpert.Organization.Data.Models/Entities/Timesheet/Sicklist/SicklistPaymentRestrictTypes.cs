using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Organization.Data.Models
{
    [Table("SicklistPaymentRestrictTypes")]
    public class SicklistPaymentRestrictType: Abstractions.IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
