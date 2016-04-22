using System.Collections.Generic;
using HRExpert.Organization.DTO;

namespace HRExpert.Organization.BL.Abstractions
{ 
    public interface IStaffEstablishedPostBL
    {
        List<StaffEstablishedPostDto> GetByDepartment(long DepartmentId);
        StaffEstablishedPostDto GetByDepartmentAndPosition(long DepartmentId, long PositionId);
    }
}