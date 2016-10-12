using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{    
    [Table("Sicklist")]
    public class Sicklist : Abstractions.IDocument
    {
        //Property
        [Key]
        public int Id { get; set; }
        [ForeignKey("Document")]
        public Guid DocumentGuid { get; set; }
        public Document Document { get; set; }
        public string SicklistNumber { get; set; }
        public DateTime? PaymentBeginDate { get; set; }
        public DateTime? PaymentDecreaseDate { get; set; }
        public bool isPreviousPaymentCounted { get; set; }
        public bool isAddToFullPayment { get; set; }
        public bool isUseBefore { get; set; }
        public bool IsContinued { get; set; }
        public int? ExperienceYears { get; set; }
        public int? ExperienceMonth {get;set;}
        
        public int StatusId { get; set; }

        //Справочники
        [ForeignKey("SicklistType")]
        public int SicklistTypeId { get; set; }
        public SicklistType SicklistType { get; set; }

        [ForeignKey("SicklistBabyMindingType")]
        public int? SicklistBabyMindingTypeId { get; set; }
        public SicklistBabyMindingType SicklistBabyMindingType { get; set; }

        [ForeignKey("SicklistPaymentRestrictType")]
        public int? SicklistPaymentRestrictTypeId { get; set; }
        public SicklistPaymentRestrictType SicklistPaymentRestrictType { get; set; }

        [ForeignKey("SicklistPaymentPercent")]
        public int? SicklistPaymentPercentId { get; set; }
        public SicklistPaymentPercent SicklistPaymentPercent { get; set; }
    }
}
