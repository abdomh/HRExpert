using System;
using System.Collections.Generic;
using HRExpert.Organization.Data.Models;
using HRExpert.Core.Data.Models;
namespace HRExpert.Organization.Data.Abstractions
{
    public interface IDocumentRepository : ExtCore.Data.Abstractions.IRepository
    {
        void Create(Document entity);
        void Delete(Guid Id);
        void Delete(Document entity);
        List<Document> List();
        List<Document> List(long PersonId);
        Document Read(Guid Id);
        void Update(Document entity);
        
    }
}