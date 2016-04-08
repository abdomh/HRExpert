using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    [Table("Modules")]
    public class Module: Parent.Referency
    {
    }
}
