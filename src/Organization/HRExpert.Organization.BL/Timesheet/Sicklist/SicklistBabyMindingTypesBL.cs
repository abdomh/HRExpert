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
        public override void SetHandler(IHandler handler)
        {
            base.SetHandler(handler);
            this.sicklistBabyMindingTypesRepository = handler.Storage.GetRepository<ISicklistBabyMindingTypesRepository>();
        }
        public SicklistBabyMindingTypesBL()
        {            
        }
        public List<SicklistBabyMindingTypeDto> List()
        {
            return this.sicklistBabyMindingTypesRepository.List().Select(x => x.Convert()).ToList();
        }
    }

}
