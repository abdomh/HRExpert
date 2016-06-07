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
    public class SicklistTypeBL : Abstractions.ISicklistTypeBL
    {
        private ISicklistTypesRepository sicklistTypesRepository;
        public SicklistTypeBL(IStorage storage, IAuthService authService)
        {
            this.sicklistTypesRepository = storage.GetRepository<ISicklistTypesRepository>();
        }
        public List<SicklistTypeDto> List()
        {
            return this.sicklistTypesRepository.List().Select(x => x.Convert()).ToList();
        }
    }
}
