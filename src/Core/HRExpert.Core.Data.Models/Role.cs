using System.Collections.Generic;
namespace HRExpert.Core.Data.Models
{
    public class Role: Parent.Referency
    {
        ICollection<RoleUsers> Users { get; set; }
    }
}
