using System.Linq;
using Microsoft.Data.Entity;

namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class OrganizationRepository : HRExpert.Core.Data.EntityFramework.SqlServer.Repository.Base.ReferencyRepositoryBase<Models.Organization>
                                , HRExpert.Organization.Data.Abstractions.IOrganizationRepository
    {
        public override Models.Organization Read(long Id)
        {
            return this.dbSet
                .Include(x => x.Departments)
                .Where(x => x.Id == Id)
                .ToList()
                .FirstOrDefault();
        }
    }
}
