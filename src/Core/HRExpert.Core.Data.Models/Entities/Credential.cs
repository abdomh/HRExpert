using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    [Table("Credentials")]
    public class Credential: Parent.Entity
    {
        [Column("Value")]
        public string Value { get; set; }
        [Column("Secret")]
        public string Secret { get; set; }
        [Column("CredentialTypeId")]
        public long CredentialTypeId {get;set;}
        [ForeignKey("CredentialTypeId")]
        public CredentialType CredentialType { get; set; }

        [ForeignKey("User")]
        public long UserId {get;set;}
        
        public User User { get; set; }
    }
}
