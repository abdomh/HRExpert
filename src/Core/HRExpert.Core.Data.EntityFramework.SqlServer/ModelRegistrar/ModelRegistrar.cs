using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Core.Data.Models;
using Microsoft.Data.Entity;
namespace HRExpert.Core.Data.EntityFramework.SqlServer.ModelRegistrar
{
    public class ModelRegistrar: IModelRegistrar
    {
        public void RegisterModels(ModelBuilder modelbuilder)
        {

          modelbuilder.Entity<User>(user =>
            {
                user.HasKey(e => e.Id);
                user.Property(e => e.Id);
                user.Property(e => e.Password);
                user.Property(e => e.Email);
            }
          );
        }
  }
}
