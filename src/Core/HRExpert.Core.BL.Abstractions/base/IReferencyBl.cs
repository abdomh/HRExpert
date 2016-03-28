using System.Collections.Generic;
using HRExpert.Core.Abstractions;
using HRExpert.Core.Data.Models.Parent;

namespace HRExpert.Core.BL.Abstractions
{
    public interface IReferencyBl
    {
        void Create(IIdName dto);
        IEnumerable<IIdName> List();
        IIdName Read(long id);
        void Update(IIdName dto);
    }
}