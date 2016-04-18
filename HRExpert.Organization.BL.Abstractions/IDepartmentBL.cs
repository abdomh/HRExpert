using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRExpert.Core.DTO;
namespace HRExpert.Organization.BL.Abstractions
{
    public interface IDepartmentBL: HRExpert.Core.BL.Abstractions.IReferencyBl
    {
        IEnumerable<IdNameDto> ListByOrganization(long OrganizationId);
    }
}
