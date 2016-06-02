using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    [Table("Sicklist")]
    public class Sicklist: Abstractions.IDocument
    {
        [Key]
        public long Id { get; set; }
        [ForeignKey("Document")]
        public Guid DocumentGuid { get; set; }
        public Document Document { get; set; }
        public string SicklistNumber { get; set; }

        [ForeignKey("SicklistType")]
        public long SicklistTypeId { get; set; }
        public SicklistType SicklistType { get; set; }
        [ForeignKey("SicklistBabyMindingType")]
        public long SicklistBabyMindingTypeId { get; set; }
        public SicklistBabyMindingType SicklistBabyMindingType { get; set; }
        [ForeignKey("SicklistPaymentRestrictType")]
        public long SicklistPaymentRestrictTypeId { get; set; }
        public SicklistPaymentRestrictType SicklistPaymentRestrictType { get; set; }
        [ForeignKey("SicklistPaymentPercent")]
        public long SicklistPaymentPercentId { get; set; }
        public SicklistPaymentPercent SicklistPaymentPercent { get; set; }
    }
}
