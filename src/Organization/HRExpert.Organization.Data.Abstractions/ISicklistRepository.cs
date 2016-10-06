﻿using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using HRExpert.Organization.Data.Models;
namespace HRExpert.Organization.Data.Abstractions
{
    public interface ISicklistRepository: Base.IRepositoryWithPermissions
    {
        void Create(Sicklist entity);
        void Delete(Sicklist entity);
        void Delete(int Id);
        List<Sicklist> List();
        List<Sicklist> List(Expression<Func<Sicklist, bool>> filter);
        Sicklist Read(int Id);
        void Update(Sicklist entity);

        List<int> GetResourceRoles(Guid DocumentGuid);
    }
}