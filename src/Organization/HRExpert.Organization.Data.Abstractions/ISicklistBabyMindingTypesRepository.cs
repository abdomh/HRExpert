using System.Collections.Generic;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.Abstractions
{
    public interface ISicklistBabyMindingTypesRepository: ExtCore.Data.Abstractions.IRepository
    {
        void Create(SicklistBabyMindingType entity);
        void Delete(SicklistBabyMindingType entity);
        void Delete(int Id);
        List<SicklistBabyMindingType> List();
        SicklistBabyMindingType Read(int Id);
        void Update(SicklistBabyMindingType entity);
    }
}