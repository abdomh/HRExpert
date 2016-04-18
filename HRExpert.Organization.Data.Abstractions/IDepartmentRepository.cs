using System.Collections.Generic;
using HRExpert.Core.Data.Abstractions;
using HRExpert.Organization.Data.Models;
namespace HRExpert.Organization.Data.Abstractions
{
    public interface IDepartmentRepository: IReferencyRepository<Department>
    {
        IEnumerable<Department> AllByOrganization(long Id);
    }
}
