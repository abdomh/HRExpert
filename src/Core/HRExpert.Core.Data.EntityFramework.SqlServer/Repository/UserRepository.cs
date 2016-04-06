using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Data.Abstractions;

namespace HRExpert.Core.Data.EntityFramework.SqlServer.Repository
{
    public class UserRepository : Base.ReferencyRepositoryBase<User>, IUserRepository
    {
        public override IEnumerable<User> All()
        {            
            return this.dbSet.ToList();                
        }
        public override User Read(long Id)
        {
            return this.dbSet
                .Include(x => x.Roles).ThenInclude(x => x.Role)
                .Include(x => x.Credentials)
                .Where(x => x.Id == Id)
                .ToList()
                .FirstOrDefault();
        }
    }
}
