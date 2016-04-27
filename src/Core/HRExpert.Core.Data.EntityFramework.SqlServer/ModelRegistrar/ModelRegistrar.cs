﻿using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Core.Data.Models;
using Microsoft.Data.Entity;
namespace HRExpert.Core.Data.EntityFramework.SqlServer.ModelRegistrar
{
    public class ModelRegistrar : IModelRegistrar
    {
        /// <summary>
        /// Регистрация моделей
        /// </summary>
        /// <param name="modelbuilder"></param>
        public void RegisterModels(ModelBuilder modelbuilder)
        {
            modelbuilder.Entity<User>();
            modelbuilder.Entity<Credential>();
            modelbuilder.Entity<CredentialType>();
            modelbuilder.Entity<Role>();
            modelbuilder.Entity<Section>();
            modelbuilder.Entity<PermissionType>();
            modelbuilder.Entity<RolePermission>().HasKey(x => new { x.RoleId, x.PermissionTypeId });
            modelbuilder.Entity<RoleUser>().HasKey(x => new { x.UserId, x.RoleId });
        }
    }
}
