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
    public class SicklistBabyMindingTypesBL: Abstractions.ISicklistBabyMindingTypesBL
    {
        private ISicklistBabyMindingTypesRepository sicklistBabyMindingTypesRepository;
        public SicklistBabyMindingTypesBL(IStorage storage, IAuthService authService)
        {
            this.sicklistBabyMindingTypesRepository = storage.GetRepository<ISicklistBabyMindingTypesRepository>();
        }
        public List<SicklistBabyMindingTypeDto> List()
        {
            return this.sicklistBabyMindingTypesRepository.List().Select(x => x.Convert()).ToList();
        }
    }

}
