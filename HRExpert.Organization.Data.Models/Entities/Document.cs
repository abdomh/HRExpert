using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    [Table("Documents")]
    public class Document: ExtCore.Data.Models.Abstractions.IEntity
    {       
        [Key]
        public Guid Id { get; set; }
        public Guid Code1C { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? SendTo1C { get; set; }
        [ForeignKey("Creator")]
        public long CreatorId { get; set; }
        public Person Creator { get; set; }
        [ForeignKey("PersonId")]
        public long PersonId { get; set; }
        public Person Person { get; set; }
        public long DocumentId { get; set; }
        [ForeignKey("DocumentType")]
        public long DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        public PersonEvent Event { get; set; }
        
    }
}
