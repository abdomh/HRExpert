using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRExpert.Organization.Data.Abstractions;
using HRExpert.Organization.DTO;
using HRExpert.Organization.BL.Converters;
using ExtCore.Data.Abstractions;
using Platformus.Barebone;
namespace HRExpert.Organization.BL
{
    public class SicklistPaymentPercentBL: Abstractions.ISicklistPaymentPercentBL
    {
        private ISicklistPaymentPercentRepository sicklistPaymentPercentRepository;
        public SicklistPaymentPercentBL(IHandler handler)
        {
            this.sicklistPaymentPercentRepository = handler.Storage.GetRepository<ISicklistPaymentPercentRepository>();
        }
        public List<SicklistPaymentPercentDto> List()
        {
            return this.sicklistPaymentPercentRepository.List().Select(x => x.Convert()).ToList();
        }
    }
}
