using System;
using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using Microsoft.Data.Entity;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class SicklistRepository: DocumentRepositoryBase<Sicklist>
    {
        public List<Sicklist> List()
        {
            return
            Query()
                .Include(x=>x.Document).ThenInclude(x=>x.Person).ThenInclude(x=>x.StaffEstablishedPost).ThenInclude(x=>x.Department).ThenInclude(x=>x.Organization)
                .Include(x => x.Document).ThenInclude(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Position)
                .Include(x=>x.Document).ThenInclude(x=>x.DocumentType)
                .Include(x=>x.SicklistBabyMindingType)
                .Include(x=>x.SicklistPaymentPercent)
                .Include(x=>x.SicklistPaymentRestrictType)
                .Include(x=>x.SicklistType)
                .ToList();
        }        
        public void Create(Sicklist entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        public Sicklist Read(long Id)
        {
            return
            Query()
                .Include(x => x.Document).ThenInclude(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Department).ThenInclude(x => x.Organization)
                .Include(x => x.Document).ThenInclude(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Position)
                .Include(x => x.Document).ThenInclude(x => x.DocumentType)
                .Include(x => x.SicklistBabyMindingType)
                .Include(x => x.SicklistPaymentPercent)
                .Include(x => x.SicklistPaymentRestrictType)
                .Include(x => x.SicklistType)
                .FirstOrDefault(x => x.Id == Id);
        }
        public void Update(Sicklist entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        public void Delete(long Id)
        {
            Delete(Read(Id));
        }
        public void Delete(Sicklist entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
