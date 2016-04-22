using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRExpert.Organization.DTO;
namespace HRExpert.Organization.BL.Abstractions
{
    public interface IPersonBL: HRExpert.Core.BL.Abstractions.IReferencyBl
    {
        List<PersonDto> GetByStaffEstablishedPost(long DepartmentId, long PositionId);
    }
}
