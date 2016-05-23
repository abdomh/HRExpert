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
        public List<Department> Childs(long organizationid, long departmentid)
        {
            return this.dbSet.Where(x => x.LeftId == departmentid && x.Distance == 1 && x.Right.OrganizationId == organizationid).Select(x=>x.Right).ToList();
        }
    }
}
