using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HRExpert.Organization.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Expressions;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore.ChangeTracking;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class SicklistRepository: DocumentRepositoryBase<Sicklist>,Abstractions.ISicklistRepository
    {
        private static IQueryable<Sicklist> IncludeAll(IQueryable<Sicklist> query)
        {
            return query
                .Include(x => x.Document).ThenInclude(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Department).ThenInclude(x => x.Organization)
                .Include(x => x.Document).ThenInclude(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Position)
                .Include(x => x.Document).ThenInclude(x => x.DocumentType)
                .Include(x=>x.Document).ThenInclude(x=>x.Approvements).ThenInclude(x=>x.Person)
                .Include(x => x.Document).ThenInclude(x => x.Approvements).ThenInclude(x => x.RealPerson)
                .Include(x => x.Document).ThenInclude(x => x.Event).ThenInclude(x => x.Timesheet).ThenInclude(x => x.Status)
                .Include(x=>x.Document).ThenInclude(x=>x.Files)
                .Include(x => x.SicklistBabyMindingType)
                .Include(x => x.SicklistPaymentPercent)
                .Include(x => x.SicklistPaymentRestrictType)
                .Include(x => x.SicklistType);
        }
        public List<Sicklist> List()
        {
            return IncludeAll(Query()).ToList();
        }   
        public List<Sicklist> List(Expression<Func<Sicklist,bool>> filter)
        {
            return IncludeAll(base.Filter(filter))
                .ToList();
        }
        public void Create(Sicklist entity)
        {            
            this.dbSet.Add(entity);            
            this.dbContext.SaveChanges();            
        }        
        public Sicklist Read(int Id)
        {
            return
             IncludeAll(Query())
                 .Single(x => x.Id == Id);                 
        }
        public void Update(Sicklist entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        public void Delete(int Id)
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
