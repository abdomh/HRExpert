using System.Linq;
using System.Collections.Generic;
using Microsoft.Data.Entity;
using HRExpert.Organization.Data.Abstractions;
using HRExpert.Organization.Data.Models;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class PersonRepository: ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<Person>, IPersonRepository
    {
        public List<Person> GetByStaffEstablishedPost(long OrganizationId, long DepartmentId, long PositionId)
        {
            return this.dbSet.Where(x => x.StaffEstablishedPost.Department.OrganizationId== OrganizationId && x.DepartmentId == DepartmentId && x.PositionId == PositionId).ToList();
        }
        public Person GetByStaffEstablishedPostAndId(long OrganizationId, long DepartmentId, long PositionId,long PersonId)
        {
            return this.dbSet.Where(x => 
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
