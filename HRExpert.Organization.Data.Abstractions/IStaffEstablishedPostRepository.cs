using System.Collections.Generic;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.Abstractions
{
    public interface IStaffEstablishedPostRepository :ExtCore.Data.Abstractions.IRepository
    {
        void Create(StaffEstablishedPost entity);
        void Edit(StaffEstablishedPost entity);
        List<StaffEstablishedPost> GetByDepartmentId(long DepartmentId);
        StaffEstablishedPost Read(long DepartmentId, long PositionId);
    }
}