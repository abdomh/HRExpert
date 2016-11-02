using System;
using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using HRExpert.Organization.Data.Models.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class DocumentStatusRepository : ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<Status>, Abstractions.IDocumentStatusRepository
    {
        public List<Status> List()
        {
            return
            this.dbSet
                .ToList();
        }
        public void Create(Status entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        public Status Read(int Id)
        {
            return
            this.dbSet
                .FirstOrDefault(x => x.Id == Id);
        }
        public Status WithCode(string code)
        {
            return this.dbSet.FirstOrDefault(x => x.Code == code);
        }
        public void Update(Status entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        public void Delete(int Id)
        {
            Delete(Read(Id));
        }
        public void Delete(Status entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }

        public List<IReference> GetReferencies()
        {
            return this.List().ToList<IReference>();
        }
    }
}
