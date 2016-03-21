using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Core.Data.Models.Abstractions
{
    public interface IObject
    {
        string Name { get; set; }
        string Description { get; set; }
        DateTime? CreateDate { get; set; }
        DateTime? DeleteDate { get; set; }
        IUser Creator { get; set; }
    }
}
