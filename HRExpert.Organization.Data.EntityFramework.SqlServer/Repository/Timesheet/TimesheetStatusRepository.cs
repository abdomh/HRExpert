﻿using System;
using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using Microsoft.EntityFrameworkCore;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class TimesheetStatusRepository : ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<TimesheetStatus>,Abstractions.ITimesheetStatusRepository
    {
        public List<TimesheetStatus> List()
        {
            return
            this.dbSet
                .ToList();
        }
        public void Create(TimesheetStatus entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        public TimesheetStatus Read(long Id)
        {
            return
            this.dbSet
                .FirstOrDefault(x => x.Id == Id);
        }
        public void Update(TimesheetStatus entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        public void Delete(long Id)
        {
            Delete(Read(Id));
        }
        public void Delete(TimesheetStatus entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
