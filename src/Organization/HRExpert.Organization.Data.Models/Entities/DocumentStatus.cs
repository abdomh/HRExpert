using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Organization.Data.Models
{
    [Table("DocumentStatuses")]
    public class DocumentStatus: Abstractions.IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
