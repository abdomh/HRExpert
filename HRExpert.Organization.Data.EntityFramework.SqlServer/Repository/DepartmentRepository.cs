using System.Linq;
using Microsoft.EntityFrameworkCore;
using HRExpert.Organization.Data.Models;
using HRExpert.Organization.Data.Abstractions;
using System.Collections.Generic;

namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    /// <summary>
    /// Репозиторий подразделений
    /// </summary>
    public class DepartmentRepository : ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<Department>, IDepartmentRepository
    {
        /// <summary>
        /// Все подразделения
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Department> All()
        {
            return this.dbSet
                .Include(x=>x.Organization)
                .ToList();
        }
        /// <summary>
        /// Все подразделения по Id организации
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public IEnumerable<Department> AllByOrganization(long Id)
        {
            return this.dbSet             
                .Include(x=>x.Organization)   
                .Where(x=>x.OrganizationId==Id)
                .ToList();
        }
        public Department ByOrganizationAndKey(long organizationid, long departmentid)
        {
            return this.dbSet
                .Include(x=>x.Organization)
                .Where(x => x.OrganizationId == organizationid && x.Id == departmentid)
                .FirstOrDefault();
        }
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Create(Department entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual Department Read(long Id)
        {
            return this.dbSet
                .Include(x=>x.Organization)
                .Where(x => x.Id == Id)
                .FirstOrDefault();
        }
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual Department ReadWithChildsAndParents(long Id)
        {
            return this.dbSet
                .Include(x=>x.Organization)                
                .Include(x=>x.Childs)
                .Include(x=>x.Parent)
                .Where(x => x.Id == Id)
                .FirstOrDefault();
        }
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(Department entity)
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
        public virtual void Delete(Department entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
        
    }
}
