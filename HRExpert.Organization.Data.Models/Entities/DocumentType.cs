using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    [Table("DocumentTypes")]
    public class DocumentType : ExtCore.Data.Models.Abstractions.IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
