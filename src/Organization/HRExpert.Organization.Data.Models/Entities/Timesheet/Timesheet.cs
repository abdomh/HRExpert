using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    [Table("Timesheet")]
    public class Timesheet : Abstractions.IEntity
    {
        [Key]
        [ForeignKey("Event")]
        public Guid DocumentGuid { get; set; }
        [ForeignKey("Status")]
        public int? StatusId {get;set;}
        public TimesheetStatus Status { get; set; }
        public PersonEvent Event { get; set; }
        public bool IsStaffEstablishedPostTemporaryFree { get; set; }
    }
}
