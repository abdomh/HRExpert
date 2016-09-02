using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    [Table("DocumentTypes")]
    public class DocumentType : Abstractions.IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
