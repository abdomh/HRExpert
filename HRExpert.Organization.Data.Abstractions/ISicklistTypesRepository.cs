using System.Collections.Generic;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.Abstractions
{
    public interface ISicklistTypesRepository : ExtCore.Data.Abstractions.IRepository
    {
        void Create(SicklistType entity);
        void Delete(SicklistType entity);
        void Delete(long Id);
        List<SicklistType> List();
        SicklistType Read(long Id);
        void Update(SicklistType entity);
    }
}