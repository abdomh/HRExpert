﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    [Table("SignedFiles")]
    public class SignedFile: ExtCore.Data.Models.Abstractions.IEntity
    {
        public SignedFile()
        {
            this.CreateDate = DateTime.Now;
        }
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("File")]
        public Guid FileId { get; set; }
        public DocumentFile File { get; set; }
        public bool DeleteAfterDownload { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
