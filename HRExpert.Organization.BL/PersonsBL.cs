using HRExpert.Organization.Data.Models;
using HRExpert.Core.Services.Abstractions;
using ExtCore.Data.Abstractions;
using HRExpert.Organization.Data.Abstractions;
using HRExpert.Organization.DTO;
using System.Collections.Generic;
using System.Linq;
namespace HRExpert.Organization.BL
{
    public class PersonsBL : Abstractions.IPersonBL
    {
        private IPersonRepository personsRepository;
        private IAuthService authService;
        public PersonsBL(IStorage storage, IAuthService authService)
        {
            this.personsRepository = storage.GetRepository<IPersonRepository>();
            this.authService = authService;
        }
        public List<PersonDto> GetByStaffEstablishedPost(long OrganizationId, long DepartmentId, long PositionId)
        {
            var result = new List<PersonDto>();
            var data = personsRepository.GetByStaffEstablishedPost(OrganizationId, DepartmentId, PositionId);
            if (data != null)
                result = data.Select(x => new PersonDto { Name = x.Name, Id = x.Id, PostCount = x.PostCount }).ToList();
            return result;
        }
        public PersonDto GetByStaffEstablishedPostAndId(long OrganizationId, long DepartmentId, long PositionId,long PersonId)
        {
            PersonDto result = null;
            var data = personsRepository.GetByStaffEstablishedPostAndId(OrganizationId, DepartmentId, PositionId, PersonId);
            if (data != null)
                result = new PersonDto { Name = data.Name, Id = data.Id, PostCount = data.PostCount };
            return result;
        }
        public void Create(PersonDto dto)
        {
            Person entity = new Person();
            entity.Name = dto.Name;
            entity.PostCount = dto.PostCount;            
        }
    }
}
