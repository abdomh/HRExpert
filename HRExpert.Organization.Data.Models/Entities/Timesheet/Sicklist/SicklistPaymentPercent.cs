using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    [Table("SicklistPaymentPercent")]
    public class SicklistPaymentPercent: ExtCore.Data.Models.Abstractions.IEntity
    {
        [Key]
        public long Id { get; set; }
        public decimal Value { get; set; }
    }
}
