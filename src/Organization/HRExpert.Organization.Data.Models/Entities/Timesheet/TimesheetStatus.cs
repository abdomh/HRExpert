using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    [Table("TimesheetStatuses")]
    public class TimesheetStatus:  Abstractions.IReference
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string ShortName { get; set; }
    }
}
