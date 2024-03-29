﻿using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    /// <summary>
    /// Репозиторий штатных единиц
    /// </summary>
    public class StaffEstablishedPostRepository : HRExpert.Core.Data.EntityFramework.SqlServer.Repository.RepositoryWithPersmissions<StaffEstablishedPost>, Abstractions.IStaffEstablishedPostRepository
    {       
        private IQueryable<StaffEstablishedPost> Query()
        {
            if(CurrentRoleId>0)
                return this.dbSet.FromSql("SELECT * FROM vwStaffEstablishedPostWithAccessLinks where AccessUserId=@p0 and AccessRoleId=@p1",CurrentUserId,CurrentRoleId);
            else
                return this.dbSet.FromSql("SELECT * FROM vwStaffEstablishedPostWithAccessLinks where AccessUserId=@p0", CurrentUserId);
        }
        /// <summary>
        /// Все по Id подразделения
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <returns></returns>
        public List<StaffEstablishedPost> GetByDepartmentId(long DepartmentId)
        {            
            return Query()
                .Include(x => x.Department).ThenInclude(x => x.Organization)
                .Include(x => x.Position)
                .Where(x=>x.DepartmentId==DepartmentId).ToList();
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
            return Query()
                .Include(x => x.Department).ThenInclude(x=>x.Organization)
                .Include(x => x.Position)
                .Where(x => x.DepartmentId == DepartmentId && x.PositionId == PositionId).FirstOrDefault();
        }        
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(StaffEstablishedPost entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
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
