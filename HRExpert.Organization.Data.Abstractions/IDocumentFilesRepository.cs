using System;
using System.Collections.Generic;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.Abstractions
{
    public interface IDocumentFilesRepository : ExtCore.Data.Abstractions.IRepository
    {
        void Create(DocumentFile entity);
        void Delete(Guid Id);
        void Delete(DocumentFile entity);
        List<DocumentFile> List();
        List<DocumentFile> List(Guid DocumentGuid);
        DocumentFile Read(Guid Id);
        void Update(DocumentFile entity);
    }
}