﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExtCore.Data.EntityFramework.Sqlite;
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
            modelbuilder.Entity<User>();            
        }
  }
}
