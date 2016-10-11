using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    [Table("Documents")]
    public class Document : Abstractions.IEntity<Guid>
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
        public int CreatorId { get; set; }
        public Person Creator { get; set; }
        [ForeignKey("PersonId")]
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int DocumentId { get; set; }
        [ForeignKey("DocumentType")]
        public int? DocumentTypeId { get; set; }
        public DocumentType DocumentType { get; set; }
        [ForeignKey("Status")]
        public int? DocumentStatusId { get; set; }        
        public Status Status { get; set; }
       
        public PersonEvent Event { get; set; }
        public ICollection<DocumentFile> Files { get; set; }
        public ICollection<DocumentApprovement> Approvements { get; set; }
    }
}
