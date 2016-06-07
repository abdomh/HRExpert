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
    public class SicklistPaymentRestrictTypesBL: Abstractions.ISicklistPaymentRestrictTypesBL
    {
        private ISicklistPaymentRestrictTypesRepository sicklistPaymentRestrictTypesRepository;
        public SicklistPaymentRestrictTypesBL(IStorage storage, IAuthService authService)
        {
            this.sicklistPaymentRestrictTypesRepository = storage.GetRepository<ISicklistPaymentRestrictTypesRepository>();
        }
        public List<SicklistPaymentRestrictTypeDto> List()
        {
            return this.sicklistPaymentRestrictTypesRepository.List().Select(x => x.Convert()).ToList();
        }
    }
}
