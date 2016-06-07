using System.Collections.Generic;
using HRExpert.Organization.DTO;

namespace HRExpert.Organization.BL.Abstractions
{
    public interface ISicklistBL
    {
        DocumentDto<SicklistDto> Create(DocumentDto<SicklistDto> dto);
        DocumentDto<SicklistDto> Read(long id);
        List<DocumentDto<SicklistDto>> List();
    }
}