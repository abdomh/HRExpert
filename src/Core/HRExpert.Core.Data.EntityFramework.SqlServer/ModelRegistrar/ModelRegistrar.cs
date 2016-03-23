using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Core.Data.Models;
using Microsoft.Data.Entity;
namespace HRExpert.Core.Data.EntityFramework.SqlServer.ModelRegistrar
{
    public class ModelRegistrar: IModelRegistrar
    {
        public void RegisterModels(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<BaseClass>();
            modelbuilder.Entity<BaseObject>();
            modelbuilder.Entity<User>( etb=> { etb.HasOne<BaseObject>(x => x.Object); });                        
        }
  }
}
