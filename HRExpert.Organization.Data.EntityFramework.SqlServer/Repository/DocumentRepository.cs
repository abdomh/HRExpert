using System;
using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class DocumentRepository: ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<Document>, Abstractions.IDocumentRepository
    {
        public List<Document> List()
        {
            return
            this.dbSet
                .Include(x => x.Person).ThenInclude(x=>x.StaffEstablishedPost).ThenInclude(x=>x.Department).ThenInclude(x=>x.Organization)
                .Include(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Position)
                .Include(x=>x.DocumentType)
                .Include(x=>x.Creator)
                .ToList();
        }
        public List<Document> List(long PersonId)
        {
            return
            this.dbSet
                .Include(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Department).ThenInclude(x => x.Organization)
                .Include(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Position)
                .Include(x => x.DocumentType)
                .Include(x => x.Creator)
                .Where(x => x.PersonId == PersonId)
                .ToList();
        }
        public void Create(Document entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        public Document Read(Guid Id)
        {
            return
            this.dbSet
                .Include(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Department).ThenInclude(x => x.Organization)
                .Include(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Position)
                .Include(x => x.DocumentType)
                .Include(x => x.Creator)
                .FirstOrDefault(x => x.Id == Id);
        }
        public void Update(Document entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        public void Delete(Guid Id)
        {
            Delete(Read(Id));
        }
        public void Delete(Document entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
