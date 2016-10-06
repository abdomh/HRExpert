using System;
using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using Microsoft.EntityFrameworkCore;
using HRExpert.Organization.Data.Models.Abstractions;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class SicklistBabyMindingTypesRepository : ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<SicklistBabyMindingType>, Abstractions.ISicklistBabyMindingTypesRepository
    {
        public List<SicklistBabyMindingType> List()
        {
            return
            this.dbSet
                .ToList();
        }
        public void Create(SicklistBabyMindingType entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        public SicklistBabyMindingType Read(int Id)
        {
            return
            this.dbSet
                .FirstOrDefault(x => x.Id == Id);
        }
        public void Update(SicklistBabyMindingType entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        public void Delete(int Id)
        {
            Delete(Read(Id));
        }
        public void Delete(SicklistBabyMindingType entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
        public List<IReference> GetReferencies()
        {
            return this.List().ToList<IReference>();
        }
    }
}
