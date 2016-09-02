using System;
using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class DocumentFilesRepository: ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<DocumentFile>, Abstractions.IDocumentFilesRepository
    {
        public List<DocumentFile> List()
        {
            return
            this.dbSet
                .Include(x => x.Document)
                .ToList();
        }
        public List<DocumentFile> List(Guid DocumentGuid)
        {
            return
            this.dbSet
                .Include(x => x.Document)
                .Where(x => x.DocumentGuid == DocumentGuid)
                .ToList();
        }
        public void Create(DocumentFile entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        public DocumentFile Read(Guid Id)
        {
            return
            this.dbSet
                .Include(x => x.Document)
                .FirstOrDefault(x => x.Id == Id);
        }
        public void Update(DocumentFile entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        public void Delete(Guid Id)
        {
            Delete(Read(Id));
        }
        public void Delete(DocumentFile entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
