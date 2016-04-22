using HRExpert.Organization.Data.Models;
using HRExpert.Core.Services.Abstractions;
using ExtCore.Data.Abstractions;
using HRExpert.Organization.Data.Abstractions;
using HRExpert.Organization.DTO;
using System.Collections.Generic;
using System.Linq;
namespace HRExpert.Organization.BL
{
    public class PersonsBL : Core.BL.ReferencyBl<Person>, Abstractions.IPersonBL
    {
        public PersonsBL(IStorage storage, IAuthService authService)
           :base(storage, authService)
        {
            var personRepository = storage.GetRepository<IPersonRepository>();
            this.SetRepository(personRepository);
        }
        public List<PersonDto> GetByStaffEstablishedPost(long DepartmentId, long PositionId)
        {
            var result = new List<PersonDto>();
            var data = ((IPersonRepository)this.ReferencyRepository).GetByStaffEstablishedPost(DepartmentId, PositionId);
            if (data != null)
                result = data.Select(x => new PersonDto { Name = x.Name, Id = x.Id, PostCount = x.PostCount }).ToList();
            return result;
        }
    }
}
