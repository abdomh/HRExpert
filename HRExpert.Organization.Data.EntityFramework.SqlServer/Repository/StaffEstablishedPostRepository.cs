using System.Collections.Generic;
using System.Linq;
using ExtCore.Data.Abstractions;
using HRExpert.Organization.Data.Models;
using Microsoft.Data.Entity;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class StaffEstablishedPostRepository : ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<StaffEstablishedPost>, Abstractions.IStaffEstablishedPostRepository
    {
        public List<StaffEstablishedPost> GetByDepartmentId(long DepartmentId)
        {
            return this.dbSet
                .Include(x=>x.Department)
                .Include(x=>x.Position)
                .Where(x => x.DepartmentId == DepartmentId).ToList();
        }
        public StaffEstablishedPost Read(long DepartmentId, long PositionId)
        {
            return this.dbSet
                .Include(x => x.Department)
                .Include(x => x.Position)
                .Where(x => x.DepartmentId == DepartmentId && x.PositionId == PositionId).FirstOrDefault();
        }
        public void Create(StaffEstablishedPost entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        public virtual void Edit(StaffEstablishedPost entity)
        {
            this.dbContext.Entry(entity).State = Microsoft.Data.Entity.EntityState.Modified;
            this.dbContext.SaveChanges();
        }
    }
}
