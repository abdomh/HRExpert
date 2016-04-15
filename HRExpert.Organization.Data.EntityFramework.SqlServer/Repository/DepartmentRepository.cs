using System.Linq;
using Microsoft.Data.Entity;
using HRExpert.Organization.Data.Models;
using HRExpert.Organization.Data.Abstractions;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class DepartmentRepository : HRExpert.Core.Data.EntityFramework.SqlServer.Repository.Base.ReferencyRepositoryBase<Department>
                                , IDepartmentRepository
    {
        public override Department Read(long Id)
        {
            return this.dbSet
                .Include(x=>x.Organization)
                .Where(x => x.Id == Id)
                .ToList()
                .FirstOrDefault();
        }
    }
}
