using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using HRExpert.Organization.Data.Abstractions;
using HRExpert.Organization.Data.Models;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    /// <summary>
    /// Репозиторий должностей
    /// </summary>
    public class PositionRepository : ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<Position>, IPositionRepository
    {
        /// <summary>
        /// Все должности
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Position> All()
        {
            return this.dbSet.ToList();
        }
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Create(Position entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual Position Read(long Id)
        {
            return this.dbSet
                .Where(x => x.Id == Id)
                .FirstOrDefault();
        }
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(Position entity)
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
        public virtual void Delete(Position entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
