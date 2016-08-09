using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HRExpert.Organization.Data.Models;
using HRExpert.Organization.Data.Models.Abstractions;
using HRExpert.Core.Data.Models;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class DocumentRepositoryBase<T>: HRExpert.Core.Data.EntityFramework.SqlServer.Repository.RepositoryWithPersmissions<T> where T: class,IDocument
    {
        public virtual IQueryable<T> Query()
        {
            return
            this.dbContext.Set<Document>()
                .FromSql("SELECT * FROM vwDocumentAccessLinks where AccessUserId=@p0", CurrentUserId)
                .Join<Document, T, Guid, T>(this.dbSet, x => x.Id, x => x.DocumentGuid, (x, y) => y);
                
        }
        public virtual List<Role> GetResourceRoles(Guid DocumentGuid)
        {
            return
            this.dbContext.Set<Role>()
                .FromSql("SELECT Distinct r.* FROM vwDocumentAccessLinks vw INNER JOIN Roles r ON vw.AccessRoleId=r.Id where vw.AccessUserId=@p0 and vw.Id=@p1", CurrentUserId, DocumentGuid)
                .AsNoTracking()
                .ToList();
        }
    }
}
