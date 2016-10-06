using System;
using System.Linq;
using System.Linq.Expressions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HRExpert.Organization.Data.Models;
using HRExpert.Organization.Data.Models.Abstractions;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class DocumentRepositoryBase<T>: Base.RepositoryWithPermissions<T> where T: class,IDocument
    {
        public virtual IQueryable<T> Query()
        {
            return
            this.dbContext.Set<Document>()
                .FromSql("SELECT * FROM vwDocumentAccessLinks where AccessUserId=@p0", CurrentUserId)
                .Join<Document, T, Guid, T>(this.dbSet, x => x.Id, x => x.DocumentGuid, (x, y) => y);
                
        }
        public virtual IQueryable<T> Filter(Expression<Func<T,bool>> filter)
        {
            return this.Query().Where(filter);
        }
        public virtual List<int> GetResourceRoles(Guid DocumentGuid)
        {
            return null;
            /*this.dbContext.
                .FromSql("SELECT Distinct r.Id FROM vwDocumentAccessLinks vw INNER JOIN Roles r ON vw.AccessRoleId=r.Id where vw.AccessUserId=@p0 and vw.Id=@p1", CurrentUserId, DocumentGuid)
                .AsNoTracking().Select(x=>x.)
                .ToList();*/
        }
    }
}
