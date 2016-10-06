using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using HRExpert.Organization.Data.Abstractions;
using HRExpert.Organization.Data.Models;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class PersonRepository: Base.RepositoryWithPermissions<Person>, IPersonRepository
    {
        private IQueryable<Person> Query()
        {
                return this.dbSet.FromSql("SELECT * FROM vwPersonsAccessLinks where AccessUserId=@p0", CurrentUserId);
        }
        public Person GetByUserId(int UserId)
        {
            return this.dbSet.FirstOrDefault(x => x.UserId == UserId);
        }
        public List<Person> GetPersonsByPermissions()
        {
            return this.Query().ToList();
        }
        public Person GetCurrentPerson()
        {
            return this.dbSet.FirstOrDefault(x => x.UserId == CurrentUserId);
        }
        public List<Person> GetByStaffEstablishedPost(int OrganizationId, int DepartmentId, int PositionId)
        {
            return Query()
                .Include(x => x.StaffEstablishedPost).ThenInclude(x => x.Department).ThenInclude(x => x.Organization)
                .Include(x => x.StaffEstablishedPost).ThenInclude(x => x.Position)
                .Where(x => x.StaffEstablishedPost.Department.OrganizationId== OrganizationId && x.DepartmentId == DepartmentId && x.PositionId == PositionId).ToList();
        }
        public Person GetByStaffEstablishedPostAndId(int OrganizationId, int DepartmentId, int PositionId,int PersonId)
        {
            return Query()
            .Include(x => x.StaffEstablishedPost).ThenInclude(x => x.Department).ThenInclude(x => x.Organization)
            .Include(x => x.StaffEstablishedPost).ThenInclude(x => x.Position)
            .Where(x => 
                x.StaffEstablishedPost.Department.OrganizationId == OrganizationId && 
                x.DepartmentId == DepartmentId && 
                x.PositionId == PositionId &&
                x.Id == PersonId
            ).FirstOrDefault();
        }
        public Person GetPersonByUserIdAndTargetDepartment(int UserId, int TargetDepartmentId)
        {
            return this.dbSet.FromSql("SELECT p.* FROM vwPersonsAccessLinks acc INNER JOIN Persons p ON acc.AccessPersonId=p.Id where AccessUserId=@p0 and acc.DepartmentId=@p1", UserId, TargetDepartmentId).FirstOrDefault();            
        }
        /// <summary>
        /// Все сотрудники
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Person> All()
        {
            return this.dbSet
                .Include(x => x.StaffEstablishedPost).ThenInclude(x => x.Department).ThenInclude(x => x.Organization)
                .Include(x => x.StaffEstablishedPost).ThenInclude(x => x.Position)
                .ToList();
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
        /// <param name="Id">идентификатор</param>
        /// <returns></returns>
        public virtual Person Read(int Id)
        {
            return this.dbSet
                .Include(x=>x.StaffEstablishedPost).ThenInclude(x=>x.Department).ThenInclude(x=>x.Organization)
                .Include(x=>x.StaffEstablishedPost).ThenInclude(x=>x.Position)
                .Where(x => x.Id == Id)
                .FirstOrDefault();
        }
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="entity">Сущность</param>
        public virtual void Update(Person entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="Id">идентификатор</param>
        public virtual void Delete(int Id)
        {
            this.Delete(Read(Id));
        }
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="entity">сущность</param>
        public virtual void Delete(Person entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
