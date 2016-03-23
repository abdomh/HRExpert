using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    /// <summary>
    /// Справочник классов
    /// </summary>
    [Table("BaseClasses")]
    public class BaseClass :  Parent.Referency
    {        
    }
}
