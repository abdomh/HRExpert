using System;
using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class SignedFilesRepository :ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<SignedFile>, Abstractions.ISignedFilesRepository
    {        
        public void Create(SignedFile entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        public SignedFile Read(Guid Id)
        {
            return
            this.dbSet
                .Include(x => x.File)
                .FirstOrDefault(x => x.Id == Id);
        }        
        public void Delete(Guid Id)
        {
            Delete(Read(Id));
        }
        public void Delete(SignedFile entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
