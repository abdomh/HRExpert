using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using HRExpert.Organization.DTO;
using HRExpert.Core.Services.Abstractions;
using HRExpert.Organization.Data.Abstractions;
using ExtCore.Data.Abstractions;
using HRExpert.Organization.Data.Models;
namespace HRExpert.Organization.BL
{
    public class StaffEstablishedPostBL: Abstractions.IStaffEstablishedPostBL
    {
        public static Expression<Func<StaffEstablishedPost, bool>> CreatePermissionsExpression(long UserId)
        {
           return x => x.Department.AccessLinks.Any(y => y!=null && y.Person.UserId == UserId)
                    || x.Department.Right.Any(k=>k!=null && k.Left.AccessLinks.Any(n=>n!=null && n.Person.UserId==UserId))
                    ;
        }
        private IStaffEstablishedPostRepository repository;
        private IAuthService authService;
        public StaffEstablishedPostBL(IAuthService authService, IStorage storage)
        {
            this.authService = authService;
            this.repository = storage.GetRepository<IStaffEstablishedPostRepository>();
            this.repository.CurrentRoleId = authService.CurrentRoleId;
            this.repository.CurrentUserId = authService.CurrentUser.Id;
        }
        public List<StaffEstablishedPostDto> GetByDepartment(long DepartmentId)
        {
            var data = repository.GetByDepartmentId(DepartmentId);
            return data?.Select(x => new StaffEstablishedPostDto
            {
                DepartmentId = x.DepartmentId,
                PositionId = x.PositionId,
                PostCount = x.PostCount
            }).ToList();
        }
        public StaffEstablishedPostDto GetByDepartmentAndPosition(long DepartmentId, long PositionId)
        {
            var data = repository.Read(DepartmentId, PositionId);
            if (data == null) return null;
            return new StaffEstablishedPostDto
            {
                DepartmentId = data.DepartmentId,
                PositionId = data.PositionId,
                PostCount = data.PostCount
            };
        }
    }
}
