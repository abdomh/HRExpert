using System.Collections.Generic;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.Abstractions
{
    public interface IDocumentTypesRepository : ExtCore.Data.Abstractions.IRepository
    {
        void Create(DocumentType entity);
        void Delete(int Id);
        void Delete(DocumentType entity);
        List<DocumentType> List();
        DocumentType Read(int Id);
        void Update(DocumentType entity);
    }
}