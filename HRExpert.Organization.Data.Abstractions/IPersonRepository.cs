using HRExpert.Core.Data.Abstractions;
using HRExpert.Organization.Data.Models;
using System.Collections.Generic;
namespace HRExpert.Organization.Data.Abstractions
{
    public interface IPersonRepository : IReferencyRepository<Person>
    {
        List<Person> GetByStaffEstablishedPost(long DepartmentId, long PositionId);
    }
}
