using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    [Table("SicklistPaymentPercent")]
    public class SicklistPaymentPercent: Abstractions.IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public decimal Value { get; set; }
    }
}
