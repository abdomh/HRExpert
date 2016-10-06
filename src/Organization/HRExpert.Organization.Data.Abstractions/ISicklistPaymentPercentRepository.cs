using System.Collections.Generic;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.Abstractions
{ 
    public interface ISicklistPaymentPercentRepository : IReferenceRepository
    {
        void Create(SicklistPaymentPercent entity);
        void Delete(SicklistPaymentPercent entity);
        void Delete(int Id);
        List<SicklistPaymentPercent> List();
        SicklistPaymentPercent Read(int Id);
        void Update(SicklistPaymentPercent entity);
    }
}