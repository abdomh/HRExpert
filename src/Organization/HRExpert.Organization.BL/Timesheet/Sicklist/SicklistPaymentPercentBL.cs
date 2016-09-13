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
    public class SicklistPaymentPercentBL: BaseBL,Abstractions.ISicklistPaymentPercentBL
    {
        private ISicklistPaymentPercentRepository sicklistPaymentPercentRepository;        
        public SicklistPaymentPercentBL(Abstractions.IMainService mainService)
            :base(mainService)
        {
            this.sicklistPaymentPercentRepository = mainService.Storage.GetRepository<ISicklistPaymentPercentRepository>();
        }
        public List<SicklistPaymentPercentDto> List()
        {
            return this.sicklistPaymentPercentRepository.List().Select(x => x.Convert()).ToList();
        }
    }
}
