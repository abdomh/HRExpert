﻿using System;
namespace HRExpert.Organization.DTO
{
    public class SicklistDto :DocumentDto
    {
        public long Id { get; set; }
        public SicklistBabyMindingTypeDto SicklistBabyMindingType { get; set; }
        public SicklistPaymentPercentDto SicklistPaymentPercent { get; set; }
        public SicklistPaymentRestrictTypeDto SicklistPaymentRestrictType { get; set; }
        public TimesheetStatusDto TimesheetStatus {get;set;}
        public SicklistTypeDto SicklistType { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string SicklistNumber { get; set; }
    }
}
