using System;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
namespace HRExpert.Organization.DTO
{
    public class SicklistDto
    {
        public int Id { get; set; }
        public SicklistBabyMindingTypeDto SicklistBabyMindingType { get; set; }
        public SicklistPaymentPercentDto SicklistPaymentPercent { get; set; }
        public SicklistPaymentRestrictTypeDto SicklistPaymentRestrictType { get; set; }
        public TimesheetStatusDto TimesheetStatus {get;set;}
        public SicklistTypeDto SicklistType { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? PaymentBeginDate { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? PaymentDecreaseDate { get; set; }
        public bool isPreviousPaymentCounted { get; set; }
        public bool IsContinue { get; set; }
        public bool isAddToFullPayment { get; set; }
        public bool isUseBefore { get; set; }
        public int? ExperienceYears { get; set; }
        public int? ExperienceMonth { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? BeginDate { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd.MM.yyyy}")]
        public DateTime? EndDate { get; set; }
        [Required]
        public string SicklistNumber { get; set; }
        //files
        public IFormFile SicklistDocument { get; set; }
    }
}
