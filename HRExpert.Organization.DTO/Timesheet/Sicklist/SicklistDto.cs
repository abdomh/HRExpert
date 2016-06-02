namespace HRExpert.Organization.DTO
{
    public class SicklistDto
    {
        public long Id { get; set; }
        public SicklistBabyMindingTypeDto SicklistBabyMindingType { get; set; }
        public SicklistPaymentPercentDto SicklistPaymentPercent { get; set; }
        public SicklistPaymentRestrictTypeDto SicklistPaymentRestrictType { get; set; }
        public TimesheetStatusDto TimesheetStatus {get;set;}
    }
}
