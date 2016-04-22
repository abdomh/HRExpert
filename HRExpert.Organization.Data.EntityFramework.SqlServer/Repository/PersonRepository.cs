using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using HRExpert.Organization.Data.Abstractions;
using HRExpert.Core.Data.EntityFramework.SqlServer.Repository.Base;
using HRExpert.Organization.Data.Models;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class PersonRepository: ReferencyRepositoryBase<Person>, IPersonRepository
    {
        public List<Person> GetByStaffEstablishedPost(long DepartmentId, long PositionId)
        {
            return this.dbSet.Where(x => x.DepartmentId == DepartmentId && x.PositionId == PositionId).ToList();
        }
    }
}
