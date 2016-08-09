using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    using Core.Data.Models.Abstractions;
    [Table("DocumentTypes")]
    public class DocumentType : IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
