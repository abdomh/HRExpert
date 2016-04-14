using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Data.Abstractions;

namespace HRExpert.Core.Data.EntityFramework.SqlServer.Repository
{
    public class PermissionTypesRepository : Base.ReferencyRepositoryBase<PermissionType>, IPermissionTypesRepository
    {
        public override IEnumerable<PermissionType> All()
        {
            return base.All();
        }
        public override PermissionType Read(long Id)
        {
            return this.dbSet
                .Include(x=>x.Section)
                .Where(x => x.Id == Id)
                .ToList()
                .FirstOrDefault();
        }
    }
}
