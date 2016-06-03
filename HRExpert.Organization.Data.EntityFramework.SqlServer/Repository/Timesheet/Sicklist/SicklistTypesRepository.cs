using System;
using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class SicklistTypesRepository : ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<SicklistType>, Abstractions.ISicklistTypesRepository
    {
        public List<SicklistType> List()
        {
            return
            this.dbSet
                .ToList();
        }
        public void Create(SicklistType entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        public SicklistType Read(long Id)
        {
            return
            this.dbSet
                .FirstOrDefault(x => x.Id == Id);
        }
        public void Update(SicklistType entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        public void Delete(long Id)
        {
            Delete(Read(Id));
        }
        public void Delete(SicklistType entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
