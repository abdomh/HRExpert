using System.Collections.Generic;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.Abstractions
{
    public interface ISicklistPaymentRestrictTypesRepository : ExtCore.Data.Abstractions.IRepository
    {
        void Create(SicklistPaymentRestrictType entity);
        void Delete(SicklistPaymentRestrictType entity);
        void Delete(long Id);
        List<SicklistPaymentRestrictType> List();
        SicklistPaymentRestrictType Read(long Id);
        void Update(SicklistPaymentRestrictType entity);
    }
}