using System.Collections.Generic;
using HRExpert.Core.Data.Models;
namespace HRExpert.Core.Data.Abstractions
{
    public interface IRoleRepository:IReferencyRepository<Role>
    {
        IList<Role> All();
    }
}
