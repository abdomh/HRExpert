using System;
using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class DocumentTypesRepository: ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<DocumentType>, Abstractions.IDocumentTypesRepository
    {
        public List<DocumentType> List()
        {
            return
            this.dbSet
                .ToList();
        }
        public void Create(DocumentType entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        public DocumentType Read(int Id)
        {
            return
            this.dbSet
                .FirstOrDefault(x => x.Id == Id);
        }
        public void Update(DocumentType entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        public void Delete(int Id)
        {
            Delete(Read(Id));
        }
        public void Delete(DocumentType entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
