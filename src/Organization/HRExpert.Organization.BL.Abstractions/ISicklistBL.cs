using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using HRExpert.Organization.DTO;

namespace HRExpert.Organization.BL.Abstractions
{
    using Data.Models;
    public interface ISicklistBL : IBaseBl
    {
        bool CheckOtherDocuments(DocumentDto<SicklistDto> dto);
        DocumentDto<SicklistDto> Create(DocumentDto<SicklistDto> dto);
        DocumentDto<SicklistDto> Update(DocumentDto<SicklistDto> dto);
        DocumentDto<SicklistDto> Read(int id);
        List<DocumentDto<SicklistDto>> GetByFilterModel(object filterModel);
        List<DocumentDto<SicklistDto>> List();
        List<DocumentDto<SicklistDto>> List(Expression<Func<Sicklist, bool>> filter);
        byte[] GetFile(int SicklistId, int FileType, out string fileName);
    }
}