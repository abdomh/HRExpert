using System.Linq;
using System.Collections.Generic;
using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Data.Abstractions;


namespace HRExpert.Core.Data.EntityFramework.SqlServer.Repository
{
    public class RoleRepository : Base.ReferencyRepositoryBase<Role>, IRoleRepository
    {
        public IList<Role> All()
        {
            return this.dbSet.Where(x => true).ToList();
        }
    }
}
