using System;
using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class TimesheetRepository: ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<Timesheet>
    {
        public List<Timesheet> List()
        {
            return
            this.dbSet
                .Include(x => x.Event).ThenInclude(x => x.Document).ThenInclude(x => x.DocumentType)
                .Include(x=>x.Event).ThenInclude(x=>x.Document).ThenInclude(x=>x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Department).ThenInclude(x => x.Organization)
                .Include(x => x.Event).ThenInclude(x => x.Document).ThenInclude(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Position)
                .ToList();
        }
        public List<Timesheet> List(long PersonId)
        {
            return
            this.dbSet
                .Include(x => x.Event).ThenInclude(x => x.Document).ThenInclude(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Department).ThenInclude(x => x.Organization)
                .Include(x => x.Event).ThenInclude(x => x.Document).ThenInclude(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Position)
                .Include(x => x.Event).ThenInclude(x => x.Document).ThenInclude(x => x.DocumentType)
                .Where(x=>x.Event.Document.PersonId == PersonId)
                .ToList();
        }
        public void Create(Timesheet entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        public Timesheet Read(Guid DocumentGuid)
        {
            return
            this.dbSet
                .Include(x => x.Event).ThenInclude(x => x.Document).ThenInclude(x=>x.DocumentType)
                .Include(x => x.Event).ThenInclude(x => x.Document).ThenInclude(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Department).ThenInclude(x => x.Organization)
                .Include(x => x.Event).ThenInclude(x => x.Document).ThenInclude(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Position)
                .FirstOrDefault(x => x.DocumentGuid == DocumentGuid);
        }
        public void Update(Timesheet entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        public void Delete(Guid DocumentGuid)
        {
            Delete(Read(DocumentGuid));
        }
        public void Delete(Timesheet entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
