using System.Collections.Generic;
using HRExpert.Organization.DTO;

namespace HRExpert.Organization.BL.Abstractions
{
    public interface ISicklistBabyMindingTypesBL : IBaseBl
    {
        List<SicklistBabyMindingTypeDto> List();
    }
}