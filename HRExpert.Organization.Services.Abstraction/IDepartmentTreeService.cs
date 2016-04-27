using System;
using System.Collections.Generic;
using HRExpert.Organization.DTO;
using HRExpert.Organization.Data.Models;
namespace HRExpert.Organization.Services.Abstraction
{
    public interface IDepartmentTreeService
    {
        bool IsChildDepartment(long ParentId, long ChildId);
        void Initialize();
        List<DepartmentDto> DepartmentTree {get;}
    }
}
