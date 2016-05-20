using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using HRExpert.Organization.Data.Abstractions;
using HRExpert.Organization.Data.Models;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class PersonRepository: HRExpert.Core.Data.EntityFramework.SqlServer.Repository.RepositoryWithPersmissions<Person>, IPersonRepository
    {
        private IQueryable<Person> Query()
        {
            return this.dbSet.FromSql("SELECT * FROM vwStaffEstablishedPostWithAccessLinks where AccessUserId=@p0 and AccessRoleId=@p1", CurrentUserId, CurrentRoleId);
        }
        public List<Person> GetByStaffEstablishedPost(long OrganizationId, long DepartmentId, long PositionId)
        {
            return Query().Where(x => x.StaffEstablishedPost.Department.OrganizationId== OrganizationId && x.DepartmentId == DepartmentId && x.PositionId == PositionId).ToList();
        }
        public Person GetByStaffEstablishedPostAndId(long OrganizationId, long DepartmentId, long PositionId,long PersonId)
        {
            return Query()
            .Where(x => 
                x.StaffEstablishedPost.Department.OrganizationId == OrganizationId && 
                x.DepartmentId == DepartmentId && 
                x.PositionId == PositionId &&
                x.Id == PersonId
            ).FirstOrDefault();
        }
        /// <summary>
        /// Все персонажи
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> All()
        {
            return this.dbSet.ToList();
        }
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Create(Person entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public virtual Person Read(long Id)
        {
            return this.dbSet
                .Where(x => x.Id == Id)
                .FirstOrDefault();
        }
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(Person entity)
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
        public virtual void Delete(Person entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
