using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Organization.Data.Models
{
    using Core.Data.Models.Abstractions;
    [Table("DocumentStatuses")]
    public class DocumentStatus: IEntity<long>
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
