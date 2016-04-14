using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Data.Abstractions;

namespace HRExpert.Core.Data.EntityFramework.SqlServer.Repository
{
    public class RoleRepository : Base.ReferencyRepositoryBase<Role>, IRoleRepository
    {
        public override Role Read(long Id)
        {
            return this.dbSet
                .Include(x => x.Permissions).ThenInclude(x=>x.PermissionType)
                .Where(x => x.Id == Id)
                .ToList()
                .FirstOrDefault();
        }
    }
}
