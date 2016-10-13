using System;
using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.DTO;
using HRExpert.Organization.Data.Abstractions;
using ExtCore.Data.Abstractions;
using HRExpert.Organization.Data.Models;
using Platformus.Barebone;
using Platformus.Security;
namespace HRExpert.Organization.BL
{
    using Converters;
    public class StaffEstablishedPostBL: BaseBL,Abstractions.IStaffEstablishedPostBL
    {     
        private IStaffEstablishedPostRepository repository;
        
        public StaffEstablishedPostBL(Abstractions.IMainService mainService)
            :base(mainService)
        {
            this.repository = mainService.Storage.GetRepository<IStaffEstablishedPostRepository>();

            this.repository.CurrentUserId = mainService.CurrentUserId;
        }
        public List<StaffEstablishedPostDto> GetByDepartment(int DepartmentId)
        {
            var data = repository.GetByDepartmentId(DepartmentId);
            return data?.Select(x => x.Convert()).ToList();
        }
        public StaffEstablishedPostDto GetByDepartmentAndPosition(int DepartmentId, int PositionId)
        {
            var data = repository.Read(DepartmentId, PositionId);
            if (data == null) return null;
            return data.Convert();
        }
    }
}
