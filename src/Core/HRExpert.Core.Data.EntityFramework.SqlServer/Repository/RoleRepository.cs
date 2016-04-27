using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Data.Abstractions;

namespace HRExpert.Core.Data.EntityFramework.SqlServer.Repository
{
    /// <summary>
    /// Хранилище ролей
    /// </summary>
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        /// <summary>
        /// Все записи
        /// </summary>
        /// <returns>Коллекция записей</returns>
        public virtual IEnumerable<Role> All()
        {
            return this.dbSet.ToList();
        }
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="entity">Сущность</param>
        public virtual void Create(Role entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="Id">Идентификатор</param>
        /// <returns>Сущность</returns>
        public virtual Role Read(long Id)
        {
            return this.dbSet.Where(x => x.Id == Id).FirstOrDefault();
        }
        /// <summary>
        /// Обновление/редактирование
        /// </summary>
        /// <param name="entity">Сущность</param>
        public virtual void Update(Role entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Удаление по идентификатору
        /// </summary>
        /// <param name="Id">Идентификатор</param>
        public virtual void Delete(long Id)
        {
            this.Delete(this.Read(Id));
        }
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="entity">Сущность</param>
        public virtual void Delete(Role entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
