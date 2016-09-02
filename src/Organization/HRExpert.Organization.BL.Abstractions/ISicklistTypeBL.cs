using System.Collections.Generic;
using HRExpert.Organization.DTO;

namespace HRExpert.Organization.BL.Abstractions
{
    public interface ISicklistTypeBL
    {
        List<SicklistTypeDto> List();
    }
}