using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using HRExpert.Organization.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class PersonEventsRepository: ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<PersonEvent>,Abstractions.IPersonEventsRepository
    {
        public List<PersonEvent> List()
        {
            return
            this.dbSet
                .Include(x=>x.Document).ThenInclude(x=>x.DocumentType)
                .Include(x => x.Document).ThenInclude(x=>x.Person).ThenInclude(x=>x.StaffEstablishedPost).ThenInclude(x=>x.Department).ThenInclude(x=>x.Organization)
                .Include(x => x.Document).ThenInclude(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Position)
                .ToList();
        }
        public List<PersonEvent> GetPersonEvents(Expression<Func<PersonEvent,bool>> searchOptions)
        {
            var query = this.dbSet.Where(x =>
                (x.Document.Status.Code == DocumentStatusCodeConstants.Codes[DocumentStatusEnum.Approved] || x.Document.Status.Code == DocumentStatusCodeConstants.Codes[DocumentStatusEnum.SendedTo1C])
                );
            if (searchOptions != null) query.Where(searchOptions);
            return query.ToList();
        }
        public void Create(PersonEvent entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        public PersonEvent Read(Guid DocumentGuid)
        {
            return
            this.dbSet
                .Include(x => x.Document).ThenInclude(x => x.DocumentType)
                .Include(x => x.Document).ThenInclude(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Department).ThenInclude(x => x.Organization)
                .Include(x => x.Document).ThenInclude(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Position)
                .FirstOrDefault(x => x.DocumentGuid == DocumentGuid);
        }
        public void Update(PersonEvent entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        public void Delete(Guid Id)
        {
            Delete(Read(Id));
        }
        public void Delete(PersonEvent entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
