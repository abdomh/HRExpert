using System.Collections.Generic;
using HRExpert.Organization.DTO;

namespace HRExpert.Organization.BL.Abstractions
{ 
    public interface IStaffEstablishedPostBL
    {
        List<StaffEstablishedPostDto> GetByDepartment(int DepartmentId);
        StaffEstablishedPostDto GetByDepartmentAndPosition(int DepartmentId, int PositionId);
    }
}