using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRExpert.Organization.DTO;
using HRExpert.Core.Services.Abstractions;
using HRExpert.Organization.Data.Abstractions;
using ExtCore.Data.Abstractions;
namespace HRExpert.Organization.BL
{
    public class StaffEstablishedPostBL: Abstractions.IStaffEstablishedPostBL
    {
        private IStaffEstablishedPostRepository repository;
        private IAuthService authService;
        public StaffEstablishedPostBL(IAuthService authService, IStorage storage)
        {
            this.authService = authService;
            this.repository = storage.GetRepository<IStaffEstablishedPostRepository>();
        }
        public List<StaffEstablishedPostDto> GetByDepartment(long DepartmentId)
        {
            var data = repository.GetByDepartmentId(DepartmentId);
            return data?.Select(x => new StaffEstablishedPostDto
            {
                Department = new DepartmentDto {  Name = x.Department.Name, Id=x.Department.Id},
                Position = new PositionDto { Id = x.Position.Id , Name = x.Position.Name},
                PostCount = x.PostCount
            }).ToList();
        }
        public StaffEstablishedPostDto GetByDepartmentAndPosition(long DepartmentId, long PositionId)
        {
            var data = repository.Read(DepartmentId, PositionId);
            if (data == null) return null;
            return new StaffEstablishedPostDto
            {
                Department = new DepartmentDto { Id = data.Department.Id, Name = data.Department.Name },
                Position = new PositionDto { Id = data.Position.Id, Name = data.Position.Name },
                PostCount = data.PostCount
            };
        }
    }
}
