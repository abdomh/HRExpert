using System.Collections.Generic;
using HRExpert.Core.Data.Models;
namespace HRExpert.Core.Data.Abstractions
{
    public interface IPermissionTypesRepository : ExtCore.Data.Abstractions.IRepository
    {
        IEnumerable<PermissionType> All();
        void Create(PermissionType entity);
        PermissionType Read(long Id);
        void Update(PermissionType entity);
        void Delete(long Id);
        void Delete(PermissionType entity);
    }
}
