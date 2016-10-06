using System;
using System.Collections.Generic;
using HRExpert.Organization.Data.Models;
using Platformus.Security.Data.Models;
namespace HRExpert.Organization.Data.Abstractions
{
    public interface IDocumentRepository : ExtCore.Data.Abstractions.IRepository
    {
        void Create(Document entity);
        void Delete(Guid Id);
        void Delete(Document entity);
        List<Document> List();
        List<Document> List(int PersonId);
        Document Read(Guid Id);
        void Update(Document entity);
        List<Person> AvailableForPersons(Guid DocumentGuid);
        List<Role> AvailableForRoles(Guid DocumentGuid, int PersonId);
        List<Permission> AvailablePermissions(Guid DocumentGuid, int PersonId);
    }
}