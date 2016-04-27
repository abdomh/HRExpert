using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRExpert.Organization.Data.Models;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class DepartmentLinksRepository: ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<DepartmentLink>, Abstractions.IDepartmentLinksRepository
    {
        public List<DepartmentLink> All()
        {
            return this.dbSet.ToList();
        }
    }
}
