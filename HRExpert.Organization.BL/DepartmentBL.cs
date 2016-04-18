using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRExpert.Organization.Data.Models;
using HRExpert.Organization.DTO;
using HRExpert.Organization.Data.Abstractions;
using ExtCore.Data.Abstractions;
using HRExpert.Core.Services.Abstractions;
using HRExpert.Organization.DTO;
using HRExpert.Core.DTO;
namespace HRExpert.Organization.BL
{
    public class DepartmentBL : HRExpert.Core.BL.ReferencyBl<HRExpert.Organization.Data.Models.Department>, Abstractions.IDepartmentBL
    {
        public DepartmentBL(IStorage storage, IAuthService authService)
           : base(storage, authService)
        {
            var departmentRepository = storage.GetRepository<IDepartmentRepository>();
            this.SetRepository(departmentRepository);
        }

        #region Public
        public override IEnumerable<IdNameDto> List()
        {
            var all = ReferencyRepository.All();
            var core = all.Where(x => !x.Right.Any()).ToList();
            var allDepartments = all.Select(x => new DepartmentDto { Id = x.Id, Name = x.Name }).ToList();
            foreach (var dep in all)
            {
                var dto = allDepartments.Where(x => x.Id == dep.Id).First();
                foreach(var child in dep.Left)
                {
                    var childdto = allDepartments.Where(x => x.Id == child.Right.Id).First();
                    dto.Childs.Add(childdto);
                }
            }
            return allDepartments.Where(x => core.Any(y => y.Id == x.Id)).ToList();
        }
        public IEnumerable<IdNameDto> ListByOrganization(long OrganizationId)
        {
            var all = ((IDepartmentRepository)ReferencyRepository).AllByOrganization(OrganizationId);
            var core = all.Where(x => !x.Right.Any()).ToList();
            var allDepartments = all.Select(x => new DepartmentDto { Id = x.Id, Name = x.Name }).ToList();
            foreach (var dep in all)
            {
                var dto = allDepartments.Where(x => x.Id == dep.Id).First();
                foreach (var child in dep.Left)
                {
                    var childdto = allDepartments.Where(x => x.Id == child.Right.Id).First();
                    dto.Childs.Add(childdto);
                }
            }
            return allDepartments.Where(x => core.Any(y => y.Id == x.Id)).ToList();
        }
        #region Converters
        public override IdNameDto ToDto(Department entity)
        {
            DepartmentDto result = new DepartmentDto();
            result.Id = entity.Id;
            result.Name = entity.Name;
            result.Organization = new OrganizationDto { Name = entity.Organization.Name, Id = entity.OrganizationId };
            foreach(var childs in entity.Left)
            {
                result.Childs.Add(new DepartmentDto { Id = childs.Right.Id, Name = childs.Right.Name });
            }
            return result;
        }
        public override void FromDto(Department entity, IdNameDto indto)
        {
            var dto = (DepartmentDto)indto;
            entity.Name = dto.Name;            
        }
        #endregion
        #endregion   
    }
}
