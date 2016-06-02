using System.Collections.Generic;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.Abstractions
{
    public interface IDocumentTypesRepository : ExtCore.Data.Abstractions.IRepository
    {
        void Create(DocumentType entity);
        void Delete(long Id);
        void Delete(DocumentType entity);
        List<DocumentType> List();
        DocumentType Read(long Id);
        void Update(DocumentType entity);
    }
}