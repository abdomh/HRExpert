using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    using Abstractions;
    [Table("AccessLinks")]
    public class AccessLink: IEntity
    {
        [ForeignKey("Person")]
        public int PersonId { get; set; }
        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
        public int RoleId { get; set; }
        public virtual Person Person { get; set; }
        public virtual Department Department { get; set; }
    }
}
