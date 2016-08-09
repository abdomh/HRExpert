using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    using Core.Data.Models.Abstractions;
    [Table("SicklistPaymentPercent")]
    public class SicklistPaymentPercent: IEntity<long>
    {
        [Key]
        public long Id { get; set; }
        public decimal Value { get; set; }
    }
}
