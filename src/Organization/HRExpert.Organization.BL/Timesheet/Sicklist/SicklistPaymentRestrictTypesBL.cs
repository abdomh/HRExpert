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
    public class SicklistPaymentRestrictTypesBL: BaseBL,Abstractions.ISicklistPaymentRestrictTypesBL
    {
        private ISicklistPaymentRestrictTypesRepository sicklistPaymentRestrictTypesRepository;
        
        public SicklistPaymentRestrictTypesBL(Abstractions.IMainService mainService)
            :base(mainService)
        {
            this.sicklistPaymentRestrictTypesRepository = mainService.Storage.GetRepository<ISicklistPaymentRestrictTypesRepository>();
        }
        public List<SicklistPaymentRestrictTypeDto> List()
        {
            return this.sicklistPaymentRestrictTypesRepository.List().Select(x => x.Convert()).ToList();
        }
    }
}
