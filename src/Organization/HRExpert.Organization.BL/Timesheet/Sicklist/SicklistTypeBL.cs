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
    public class SicklistTypeBL : BaseBL,Abstractions.ISicklistTypeBL
    {
        private ISicklistTypesRepository sicklistTypesRepository;
        
        public SicklistTypeBL(Abstractions.IMainService mainService)
            :base(mainService)
        {
            this.sicklistTypesRepository = mainService.Storage.GetRepository<ISicklistTypesRepository>();
        }
        public List<SicklistTypeDto> List()
        {
            return this.sicklistTypesRepository.List().Select(x => x.Convert()).ToList();
        }
    }
}
