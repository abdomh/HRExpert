using System.Collections.Generic;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.Abstractions
{
    public interface IDepartmentLinksRepository : ExtCore.Data.Abstractions.IRepository
    {
        List<DepartmentLink> All();
        List<Department> Childs(long organizationid, long departmentid);
    }
}