using System;
using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using Microsoft.Data.Entity;

namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class DocumentApprovementsRepository: ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<DocumentApprovement>, Abstractions.IDocumentApprovementsRepository
    {
        public List<DocumentApprovement> List()
        {
            return
            this.dbSet
                .Include(x => x.Document)
                .Include(x => x.Person)
                .ToList();
        }
        public List<DocumentApprovement> List(Guid DocumentGuid)
        {
            return
                this.dbSet
                .Include(x => x.Document)
                .Include(x => x.Person)
                .Where(x => x.DocumentGuid == DocumentGuid)
                .ToList();
        }
        public void Create(DocumentApprovement entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        public DocumentApprovement Read(Guid DocumentGuid, int ApprovePosition)
        {
            return
            this.dbSet
                .Include(x => x.Document)
                .Include(x => x.Person)
                .FirstOrDefault(x => x.ApprovePosition == ApprovePosition && x.DocumentGuid == DocumentGuid);
        }
        public void Update(DocumentApprovement entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        public void Delete(Guid DocumentGuid, int ApprovePosition)
        {
            Delete(Read(DocumentGuid, ApprovePosition));
        }
        public void Delete(DocumentApprovement entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
