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
            modelbuilder.Entity<DepartmentLink>().HasKey(x => new { x.LeftId, x.RightId });
            
        }
    }
}
