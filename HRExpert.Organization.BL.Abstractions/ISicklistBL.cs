using System.Collections.Generic;
using HRExpert.Organization.DTO;

namespace HRExpert.Organization.BL.Abstractions
{
    public interface ISicklistBL
    {
        SicklistDto Create(SicklistDto dto);
        SicklistDto Read(long id);
        List<SicklistDto> List();
    }
}