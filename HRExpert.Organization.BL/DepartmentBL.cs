using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using HRExpert.Organization.DTO;
using HRExpert.Organization.Data.Abstractions;
using ExtCore.Data.Abstractions;
using HRExpert.Core.Services.Abstractions;
namespace HRExpert.Organization.BL
{
    public class DepartmentBL : Abstractions.IDepartmentBL
    {
        private IAuthService authService;
        private IDepartmentRepository departmentRepository;
        public DepartmentBL(IStorage storage, IAuthService authService)
        {
            this.departmentRepository = storage.GetRepository<IDepartmentRepository>();
            this.authService = authService;
        }

        #region Public
        public IEnumerable<DepartmentDto> List()
        {
            var all = departmentRepository.All();
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
        public IEnumerable<DepartmentDto> ListByOrganization(long OrganizationId)
        {
            var all = departmentRepository.AllByOrganization(OrganizationId);
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
        public virtual DepartmentDto Create(DepartmentDto dto)
        {
            var entity = new Department { Name = dto.Name };
            this.departmentRepository.Create(entity);
            return ToDto(entity);
        }
        public virtual DepartmentDto Read(long id)
        {
            return ToDto(departmentRepository.Read(id));
        }
        public virtual DepartmentDto Update(DepartmentDto dto)
        {
            var entity = departmentRepository.Read(dto.Id);
            this.FromDto(entity, dto);
            departmentRepository.Update(entity);
            return ToDto(entity);
        }
        public virtual DepartmentDto Delete(long id)
        {
            var entity = departmentRepository.Read(id);
            entity.Delete = true;
            departmentRepository.Update(entity);
            return ToDto(entity);
        }
        #region Converters
        public DepartmentDto ToDto(Department entity)
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
        public void FromDto(Department entity, DepartmentDto indto)
        {
            var dto = (DepartmentDto)indto;
            entity.Name = dto.Name;            
        }
        #endregion
        #endregion   
    }
}
