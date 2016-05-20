using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using HRExpert.Organization.Data.Models;
using HRExpert.Organization.DTO;

namespace HRExpert.Organization.BL.Abstractions
{ 
    public interface IStaffEstablishedPostBL
    {
        List<StaffEstablishedPostDto> GetByDepartment(long DepartmentId);
        StaffEstablishedPostDto GetByDepartmentAndPosition(long DepartmentId, long PositionId);
        //Expression<Func<StaffEstablishedPost, bool>> CreatePermissionsExpression(long UserId);
    }
}