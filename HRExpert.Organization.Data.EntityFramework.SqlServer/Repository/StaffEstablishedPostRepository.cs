using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using Microsoft.Data.Entity;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    /// <summary>
    /// Репозиторий штатных единиц
    /// </summary>
    public class StaffEstablishedPostRepository : ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<StaffEstablishedPost>, Abstractions.IStaffEstablishedPostRepository
    {
        /// <summary>
        /// Все по Id подразделения
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <returns></returns>
        public List<StaffEstablishedPost> GetByDepartmentId(long DepartmentId)
        {
            return this.dbSet
                .Include(x=>x.Department)
                .Include(x=>x.Position)
                .Where(x => x.DepartmentId == DepartmentId).ToList();
        }
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="entity"></param>
        public void Create(StaffEstablishedPost entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <param name="PositionId"></param>
        /// <returns></returns>
        public StaffEstablishedPost Read(long DepartmentId, long PositionId)
        {
            return this.dbSet
                .Include(x => x.Department)
                .Include(x => x.Position)
                .Where(x => x.DepartmentId == DepartmentId && x.PositionId == PositionId).FirstOrDefault();
        }        
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(StaffEstablishedPost entity)
        {
            this.dbContext.Entry(entity).State = Microsoft.Data.Entity.EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <param name="PositionId"></param>
        public virtual void Delete(long DepartmentId, long PositionId)
        {
            Delete(Read(DepartmentId,PositionId));
        }
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(StaffEstablishedPost entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
