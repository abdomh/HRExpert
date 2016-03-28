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
        public IEnumerable<T> All()
        {
            return this.dbSet.ToList();
        }
        public IEnumerable<T> Range(int take, int skip)
        {
            return Range(this.dbSet, take, skip).ToList();
        }
        public T Read(long Id)
        {
            return this.WithKey(Id);
        }
        public void Update(T entity)
        {
            this.Edit(entity);
        }
        public T GetByCode(string code)
        {
            return this.dbSet.FirstOrDefault(x => x.Code == code);
        }
        public T WithKey(long Id)
        {
            return this.dbSet.FirstOrDefault(x => x.Id == Id);            
        }
        public void Edit(T entity)
        {
            this.dbContext.Entry(entity).State = Microsoft.Data.Entity.EntityState.Modified;                        
        }
        public void Delete(long Id)
        {
            this.Delete(this.WithKey(Id));
        }
        public void Create(T entity)
        {
            this.dbSet.Add(entity);
        }
        public void Delete(T entity)
        {
            this.dbSet.Remove(entity);
        }

        public IQueryable<T> Range(IQueryable<T> collection, int take, int skip)
        {
            return collection.Skip(skip).Take(take);
        }

        
    }
}
