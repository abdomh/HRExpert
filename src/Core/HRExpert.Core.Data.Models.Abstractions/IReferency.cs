using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Core.Data.Models.Abstractions
{
    public interface IReferency: IEntity
    {
        string Name { get; set; }
    }
}
