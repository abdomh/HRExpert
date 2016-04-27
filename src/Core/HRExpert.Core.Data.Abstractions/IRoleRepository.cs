using System.Collections.Generic;
using HRExpert.Core.Data.Models;
namespace HRExpert.Core.Data.Abstractions
{
    public interface IRoleRepository: ExtCore.Data.Abstractions.IRepository
    {
        IEnumerable<Role> All();
        void Create(Role entity);
        Role Read(long Id);
        void Update(Role entity);
        void Delete(long Id);
        void Delete(Role entity);
    }
}
