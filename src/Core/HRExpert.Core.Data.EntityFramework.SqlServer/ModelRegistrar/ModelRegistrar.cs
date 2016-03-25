using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Core.Data.Models;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata.Builders;
namespace HRExpert.Core.Data.EntityFramework.SqlServer.ModelRegistrar
{
    public class ModelRegistrar : IModelRegistrar
    {
        public void RegisterModels(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<BaseClass>();
            modelbuilder.Entity<BaseObject>();
            modelbuilder.Entity<User>();
            modelbuilder.Entity<Credential>();
            modelbuilder.Entity<CredentialType>();
            modelbuilder.Entity<Role>();
            modelbuilder.Entity<PermissionType>();
            modelbuilder.Entity<RolePermission>().HasKey(x => new { x.RoleId, x.PermissionTypeId });
            modelbuilder.Entity<RoleUser>().HasKey(x => new { x.UserId, x.RoleId });
        }
    }
}
