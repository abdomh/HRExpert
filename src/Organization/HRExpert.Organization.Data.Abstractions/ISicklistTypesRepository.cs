using System.Collections.Generic;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.Abstractions
{
    public interface ISicklistTypesRepository : IReferenceRepository
    {
        void Create(SicklistType entity);
        void Delete(SicklistType entity);
        void Delete(int Id);
        List<SicklistType> List();
        SicklistType Read(int Id);
        void Update(SicklistType entity);
    }
}