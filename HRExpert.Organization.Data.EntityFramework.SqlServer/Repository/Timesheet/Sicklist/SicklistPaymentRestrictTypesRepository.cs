using System;
using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class SicklistPaymentRestrictTypesRepository:ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<SicklistPaymentRestrictType> , Abstractions.ISicklistPaymentRestrictTypesRepository
    {
        public List<SicklistPaymentRestrictType> List()
        {
            return
            this.dbSet
                .ToList();
        }
        public void Create(SicklistPaymentRestrictType entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        public SicklistPaymentRestrictType Read(long Id)
        {
            return
            this.dbSet
                .FirstOrDefault(x => x.Id == Id);
        }
        public void Update(SicklistPaymentRestrictType entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        public void Delete(long Id)
        {
            Delete(Read(Id));
        }
        public void Delete(SicklistPaymentRestrictType entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
