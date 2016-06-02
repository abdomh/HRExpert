using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    [Table("PersonEvents")]
    public class PersonEvent: ExtCore.Data.Models.Abstractions.IEntity
    {
        [Key]
        [ForeignKey("Document")]
        public Guid DocumentGuid { get; set; }
        public Document Document { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Timesheet Timesheet { get; set; }
    }
}
