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
        public override void SetHandler(IHandler handler)
        {
            base.SetHandler(handler);
            this.sicklistPaymentPercentRepository = handler.Storage.GetRepository<ISicklistPaymentPercentRepository>();
        }
        public SicklistPaymentPercentBL()
        {            
        }
        public List<SicklistPaymentPercentDto> List()
        {
            return this.sicklistPaymentPercentRepository.List().Select(x => x.Convert()).ToList();
        }
    }
}
