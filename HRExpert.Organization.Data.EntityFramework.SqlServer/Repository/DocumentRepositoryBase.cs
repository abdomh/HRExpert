using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HRExpert.Organization.Data.Models;
using HRExpert.Organization.Data.Models.Abstractions;

namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class DocumentRepositoryBase<T>: HRExpert.Core.Data.EntityFramework.SqlServer.Repository.RepositoryWithPersmissions<T> where T: class,IDocument
    {
        public virtual IQueryable<T> Query()
        {
            return
            this.dbContext.Set<Document>()
                .FromSql("SELECT sl.* FROM vwDocumentAccessLinks where AccessUserId=@p0 and AccessRoleId=@p1", CurrentUserId, CurrentRoleId)
                .Join<Document, T, Guid, T>(this.dbSet, x => x.Id, x => x.DocumentGuid, (x, y) => y);
        }
    }
}
