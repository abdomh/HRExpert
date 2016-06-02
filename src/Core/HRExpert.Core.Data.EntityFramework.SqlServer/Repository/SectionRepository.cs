using System.Linq;
using System.Collections.Generic;
using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Data.Abstractions;

namespace HRExpert.Core.Data.EntityFramework.SqlServer.Repository
{
    /// <summary>
    /// Хранилище модулей
    /// </summary>
    public class SectionRepository : RepositoryBase<Section>, ISectionRepository
    {
        /// <summary>
        /// Все записи
        /// </summary>
        /// <returns>Коллекция записей</returns>
        public virtual IEnumerable<Section> All()
        {
            return this.dbSet.ToList();
        }
        /// <summary>
        /// Создание сущности
        /// </summary>
        /// <param name="entity">Сущность</param>
        public virtual void Create(Section entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Чтение сущности по идентификатору
        /// </summary>
        /// <param name="Id">идентификатор</param>
        /// <returns></returns>
        public virtual Section Read(long Id)
        {
            return this.dbSet.Where(x => x.Id == Id).FirstOrDefault();
        }
        /// <summary>
        /// Обновление/редактирование сущности
        /// </summary>
        /// <param name="entity">Сущность</param>
        public virtual void Update(Section entity)
        {
            this.dbContext.Entry(entity).State = Microsoft.Data.Entity.EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Удаление сущности по идетнификатору
        /// </summary>
        /// <param name="Id">идентификатор</param>
        public virtual void Delete(long Id)
        {
            this.Delete(this.Read(Id));
        }
        /// <summary>
        /// Удаление сущности
        /// </summary>
        /// <param name="entity">Сущность</param>
        public virtual void Delete(Section entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
