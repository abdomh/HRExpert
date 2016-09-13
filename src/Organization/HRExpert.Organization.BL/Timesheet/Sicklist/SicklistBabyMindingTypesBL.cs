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
    public class SicklistBabyMindingTypesBL: BaseBL,Abstractions.ISicklistBabyMindingTypesBL
    {
        private ISicklistBabyMindingTypesRepository sicklistBabyMindingTypesRepository;
        
        public SicklistBabyMindingTypesBL(Abstractions.IMainService mainService)
            :base(mainService)
        {            
        }
        public List<SicklistBabyMindingTypeDto> List()
        {
            return this.sicklistBabyMindingTypesRepository.List().Select(x => x.Convert()).ToList();
        }
    }

}
