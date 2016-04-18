using System.Linq;
using Microsoft.Data.Entity;
using HRExpert.Organization.Data.Models;
using HRExpert.Organization.Data.Abstractions;
using System.Collections.Generic;

namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class DepartmentRepository : HRExpert.Core.Data.EntityFramework.SqlServer.Repository.Base.ReferencyRepositoryBase<Department>
                                , IDepartmentRepository
    {
        public override IEnumerable<Department> All()
        {
            return this.dbSet
                .Include(x => x.Organization)
                .Include(x => x.Left)
                    .ThenInclude(x => x.Right)        
                .Include(x=>x.Right)                              
                    .ThenInclude(x=>x.Left)
                .ToList();
        }
        public IEnumerable<Department> AllByOrganization(long Id)
        {
            return this.dbSet
                .Include(x => x.Organization)
                .Include(x => x.Left)
                    .ThenInclude(x => x.Right)
                .Include(x => x.Right)
                    .ThenInclude(x => x.Left)
                .Where(x=>x.OrganizationId==Id)
                .ToList();
        }
        public override Department Read(long Id)
        {
            return this.dbSet
                .Include(x=>x.Right).ThenInclude(x=>x.Left)
                .Include(x=>x.Left).ThenInclude(x=>x.Right)
                .Include(x=>x.Organization)
                .Where(x => x.Id == Id)
                .ToList()
                .FirstOrDefault();
        }
    }
}
