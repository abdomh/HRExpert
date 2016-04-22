using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;
using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.EntityFramework.SqlServer
{
    public class ModelRegistrar : IModelRegistrar
    {
        public void RegisterModels(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<Models.Organization>();
            modelbuilder.Entity<Department>();
            modelbuilder.Entity<DepartmentLink>().HasOne(x => x.Left).WithMany(x => x.Left).HasForeignKey(x=>x.LeftId);
            modelbuilder.Entity<DepartmentLink>().HasOne(x => x.Right).WithMany(x => x.Right).HasForeignKey(x=>x.RightId);
            modelbuilder.Entity<DepartmentLink>().HasKey(x => new { x.LeftId, x.RightId });
            modelbuilder.Entity<Person>().HasOne(x=>x.StaffEstablishedPost);
            modelbuilder.Entity<Position>();
            modelbuilder.Entity<StaffEstablishedPost>().HasKey(x => new { x.DepartmentId, x.PositionId });
        }
    }
}
