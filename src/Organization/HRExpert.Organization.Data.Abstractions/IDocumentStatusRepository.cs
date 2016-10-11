using System.Collections.Generic;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.Abstractions
{
    public interface IDocumentStatusRepository : ExtCore.Data.Abstractions.IRepository
    {
        void Create(Status entity);
        void Delete(int Id);
        void Delete(Status entity);
        List<Status> List();
        Status Read(int Id);
        void Update(Status entity);
        Status WithCode(string code);
    }
}