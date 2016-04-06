using System.Linq;
using System.Collections.Generic;
using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Data.Models.Parent;
using HRExpert.Core.Data.Abstractions;

namespace HRExpert.Core.Data.EntityFramework.SqlServer.Repository.Base
{
    public class ReferencyRepositoryBase<T>: RepositoryBase<T> where T : Referency
    {
        public virtual IEnumerable<T> All()
        {
            return this.dbSet.ToList();
        }
        public virtual IEnumerable<T> Range(int take, int skip)
        {
            return Range(this.dbSet, take, skip).ToList();
        }
        public virtual T Read(long Id)
        {
            return this.WithKey(Id);
        }
        public virtual void Update(T entity)
        {
            this.Edit(entity);
        }
        public virtual T GetByCode(string code)
        {            
            return this.dbSet.Where(x => x.Code == code).ToList().FirstOrDefault();
        }
        public virtual T WithKey(long Id)
        {            
            return this.dbSet.Where(x => x.Id == Id).ToList().FirstOrDefault();            
        }
        public virtual void Edit(T entity)
        {
            this.dbContext.Entry(entity).State = Microsoft.Data.Entity.EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        public virtual void Delete(long Id)
        {
            this.Delete(this.WithKey(Id));
        }
        public virtual void Create(T entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        public virtual void Delete(T entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }

        public virtual IQueryable<T> Range(IQueryable<T> collection, int take, int skip)
        {
            return collection.Skip(skip).Take(take);
        }

        
    }
}
