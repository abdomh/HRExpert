using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Organization.Data.Models.Abstractions
{
    public interface IReference: IEntity<int>
    {
        string Name { get; set; }
        string Code { get; set; }
    }
}
