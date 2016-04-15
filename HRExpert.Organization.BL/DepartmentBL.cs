using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRExpert.Organization.Data.Models;
using HRExpert.Organization.DTO;
using HRExpert.Organization.Data.Abstractions;
using ExtCore.Data.Abstractions;
using HRExpert.Core.Services.Abstractions;
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
    }
}
