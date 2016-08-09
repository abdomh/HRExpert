﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HRExpert.Organization.Data.Models
{
    using Core.Data.Models.Abstractions;
    [Table("SicklistBabyMindingTypes")]
    public class SicklistBabyMindingType: IEntity<long>
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}
