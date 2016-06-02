using System;
using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using Microsoft.Data.Entity;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class SicklistPaymentPercentRepository : ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<SicklistPaymentPercent>, Abstractions.ISicklistPaymentPercentRepository
    {
        public List<SicklistPaymentPercent> List()
        {
            return
            this.dbSet
                .ToList();
        }
        public void Create(SicklistPaymentPercent entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        public SicklistPaymentPercent Read(long Id)
        {
            return
            this.dbSet
                .FirstOrDefault(x => x.Id == Id);
        }
        public void Update(SicklistPaymentPercent entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        public void Delete(long Id)
        {
            Delete(Read(Id));
        }
        public void Delete(SicklistPaymentPercent entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
