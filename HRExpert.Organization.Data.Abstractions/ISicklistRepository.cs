using System.Collections.Generic;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.Abstractions
{
    public interface ISicklistRepository: HRExpert.Core.Data.Abstractions.IRepositoryWithPermissions
    {
        void Create(Sicklist entity);
        void Delete(Sicklist entity);
        void Delete(long Id);
        List<Sicklist> List();
        Sicklist Read(long Id);
        void Update(Sicklist entity);
    }
}