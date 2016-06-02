using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    [Table("SicklistTypes")]
    public class SicklistType : ExtCore.Data.Models.Abstractions.IEntity
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
