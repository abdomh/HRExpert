using System.Linq;
using System.Collections.Generic;
using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Data.Abstractions;
using Microsoft.EntityFrameworkCore;
namespace HRExpert.Core.Data.EntityFramework.SqlServer.Repository
{
    /// <summary>
    /// Хранилище типов учётных данных
    /// </summary>
    public class CredentialTypesitory : RepositoryBase<CredentialType>, ICredentialTypesRepository
    {
        /// <summary>
        /// Все записи
        /// </summary>
        /// <returns>Коллекция данных</returns>
        public virtual IEnumerable<CredentialType> All()
        {
            return this.dbSet.ToList();
        }
        /// <summary>
        /// Создание сущности
        /// </summary>
        /// <param name="entity">Сущность</param>
        public virtual void Create(CredentialType entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Чтение сущности по идентификатору
        /// </summary>
        /// <param name="Id">Идентификатор</param>
        /// <returns>Сущность</returns>
        public virtual CredentialType Read(long Id)
        {
            return this.dbSet.Where(x => x.Id == Id).FirstOrDefault();
        }       
        /// <summary>
        /// Обновление/редактирование сущности
        /// </summary>
        /// <param name="entity">Сущность</param>
        public virtual void Update(CredentialType entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Удаление сущности по идетификатору
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
        public virtual void Delete(CredentialType entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
