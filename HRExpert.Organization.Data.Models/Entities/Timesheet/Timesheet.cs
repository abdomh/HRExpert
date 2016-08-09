using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    using Core.Data.Models.Abstractions;
    [Table("Timesheet")]
    public class Timesheet : IEntity
    {
        [Key]
        [ForeignKey("Event")]
        public Guid DocumentGuid { get; set; }
        [ForeignKey("Status")]
        public long? StatusId {get;set;}
        public TimesheetStatus Status { get; set; }
        public PersonEvent Event { get; set; }
        public bool IsStaffEstablishedPostTemporaryFree { get; set; }
    }
}
