using System;
using Microsoft.AspNetCore.Http;
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
        public DateTime? PaymentBeginDate { get; set; }
        public DateTime? PaymentDecreaseDate { get; set; }
        public bool isPreviousPaymentCounted { get; set; }
        public bool isAddToFullPayment { get; set; }
        public bool isUseBefore { get; set; }
        public int? ExperienceYears { get; set; }
        public int? ExperienceMonth { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string SicklistNumber { get; set; }
        //files
        public IFormFile SicklistDocument { get; set; }
    }
}
