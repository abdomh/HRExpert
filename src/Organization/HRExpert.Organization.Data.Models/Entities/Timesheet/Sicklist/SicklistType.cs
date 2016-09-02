using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    [Table("SicklistTypes")]
    public class SicklistType : Abstractions.IEntity<int>
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
