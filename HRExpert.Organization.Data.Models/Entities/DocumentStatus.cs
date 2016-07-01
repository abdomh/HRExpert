using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Organization.Data.Models
{
    [Table("DocumentStatuses")]
    public class DocumentStatus
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
