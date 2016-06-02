using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    [Table("TimesheetStatuses")]
    public class TimesheetStatus: ExtCore.Data.Models.Abstractions.IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
    }
}
