using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    using Core.Data.Models.Abstractions;
    [Table("Documents")]
    public class Document : IEntity<Guid>
    {
        public Document()
        {
            this.Files = new List<DocumentFile>();
        }
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
        public long? DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        public long? DocumentStatusId { get; set; }
        public DocumentStatus Status { get; set; }
        public PersonEvent Event { get; set; }
        public ICollection<DocumentFile> Files { get; set; }
        public ICollection<DocumentApprovement> Approvements { get; set; }
    }
}
