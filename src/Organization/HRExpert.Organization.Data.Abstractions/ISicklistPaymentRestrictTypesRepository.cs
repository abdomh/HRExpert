using System.Collections.Generic;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.Abstractions
{
    public interface ISicklistPaymentRestrictTypesRepository : IReferenceRepository
    {
        void Create(SicklistPaymentRestrictType entity);
        void Delete(SicklistPaymentRestrictType entity);
        void Delete(int Id);
        List<SicklistPaymentRestrictType> List();
        SicklistPaymentRestrictType Read(int Id);
        void Update(SicklistPaymentRestrictType entity);
    }
}