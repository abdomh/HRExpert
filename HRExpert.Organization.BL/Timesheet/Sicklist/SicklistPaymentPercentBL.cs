using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRExpert.Organization.Data.Abstractions;
using HRExpert.Organization.DTO;
using HRExpert.Organization.BL.Converters;
using ExtCore.Data.Abstractions;
using HRExpert.Core.Services.Abstractions;
namespace HRExpert.Organization.BL
{
    public class SicklistPaymentPercentBL: Abstractions.ISicklistPaymentPercentBL
    {
        private ISicklistPaymentPercentRepository sicklistPaymentPercentRepository;
        public SicklistPaymentPercentBL(IStorage storage, IAuthService authService)
        {
            this.sicklistPaymentPercentRepository = storage.GetRepository<ISicklistPaymentPercentRepository>();
        }
        public List<SicklistPaymentPercentDto> List()
        {
            return this.sicklistPaymentPercentRepository.List().Select(x => x.Convert()).ToList();
        }
    }
}
