using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    /// <summary>
    /// Репозиторий организаций
    /// </summary>
    public class OrganizationRepository : ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<Models.Organization>, Abstractions.IOrganizationRepository
    {
        /// <summary>
        /// Все организации
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Models.Organization> All()
        {
            return this.dbSet.ToList();
        }        
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Create(Models.Organization entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual Models.Organization Read(long Id)
        {
            return this.dbSet
                .Where(x => x.Id == Id)
                .FirstOrDefault();
        }
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(Models.Organization entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="Id"></param>
        public virtual void Delete(long Id)
        {
            this.Delete(Read(Id));
        }
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(Models.Organization entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
