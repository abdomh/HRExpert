using System.Collections.Generic;
using HRExpert.Core.Data.Models;
namespace HRExpert.Core.Data.Abstractions
{
    public interface IRoleRepository:ExtCore.Data.Abstractions.IRepository
    {
        IList<Role> All();
    }
}
