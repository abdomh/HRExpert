using System;
using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using Platformus.Security.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class DocumentRepository: ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<Document>, Abstractions.IDocumentRepository
    {
        public List<Person> AvailableForPersons(Guid DocumentGuid)
        {            
            return this.dbContext.Set<Person>().FromSql("SELECT pers.* FROM vwDocumentAccess vw INNER JOIN Persons pers on pers.Id = vw.AccessPersonId where vw.DocumentGuid={0}",DocumentGuid)
                .Include(x=>x.StaffEstablishedPost).ThenInclude(x=>x.Department).ThenInclude(x=>x.Organization)
                .Include(x => x.StaffEstablishedPost).ThenInclude(x => x.Position)                
                .ToList();
        }
        public List<Role> AvailableForRoles(Guid DocumentGuid, int PersonId)
        {
            return this.dbContext.Set<Role>().FromSql("SELECT role.* FROM vwDocumentAccess vw INNER JOIN Roles role on role.Id = vw.AccessRoleId where vw.DocumentGuid={0} and vw.AccessPersonId={1}", DocumentGuid,PersonId)
                              
                .ToList();
        }
        public List<Permission> AvailablePermissions(Guid DocumentGuid, int PersonId)
        {
            return this.dbContext.Set<Permission>().FromSql("SELECT DISTINCT perm.* FROM vwDocumentAccess vw INNER JOIN Roles role on role.Id = vw.AccessRoleId INNER JOIN RolePermissions rp on role.Id = rp.RoleId INNER JOIN Permissions perm on perm.Id=rp.PermissionId  where vw.DocumentGuid={0} and vw.AccessPersonId={1}", DocumentGuid, PersonId)
                
                .ToList();
        }
        public List<Document> List()
        {
            return
            this.dbSet
                .Include(x => x.Person).ThenInclude(x=>x.StaffEstablishedPost).ThenInclude(x=>x.Department).ThenInclude(x=>x.Organization)
                .Include(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Position)
                .Include(x=>x.DocumentType)
                .Include(x=>x.Creator)
                .ToList();
        }
        public List<Document> List(int PersonId)
        {
            return
            this.dbSet
                .Include(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Department).ThenInclude(x => x.Organization)
                .Include(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Position)
                .Include(x => x.DocumentType)
                .Include(x => x.Creator)
                .Where(x => x.PersonId == PersonId)
                .ToList();
        }
        public void Create(Document entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        public Document Read(Guid Id)
        {
            return
            this.dbSet
                .Include(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Department).ThenInclude(x => x.Organization)
                .Include(x => x.Person).ThenInclude(x => x.StaffEstablishedPost).ThenInclude(x => x.Position)
                .Include(x => x.DocumentType)
                .Include(x => x.Creator)
                .FirstOrDefault(x => x.Id == Id);
        }
        public void Update(Document entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        public void Delete(Guid Id)
        {
            Delete(Read(Id));
        }
        public void Delete(Document entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
