using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Core.Data.Models;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;
namespace HRExpert.Core.Data.EntityFramework.SqlServer.ModelRegistrar
{
    public class ModelRegistrar: IModelRegistrar
    {
        public void RegisterModels(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<BaseClass>();
            modelbuilder.Entity<BaseObject>();
            modelbuilder.Entity<User>( etb=> 
            {                
                etb.HasOne<BaseObject>(x => x.Object);
            }      
            );
            modelbuilder.Entity<RoleUsers>().HasKey(x => new { x.UserId, x.RoleId });
        }
  }
}
