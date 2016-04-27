using System.Collections.Generic;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public interface IDepartmentLinksRepository
    {
        List<DepartmentLink> All();
    }
}