using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRExpert.Organization.Data.Abstractions;
using HRExpert.Organization.DTO;
using HRExpert.Organization.BL.Converters;
using ExtCore.Data.Abstractions;
using Platformus.Barebone;
namespace HRExpert.Organization.BL
{
    public class TimesheetStatusBL: BaseBL,Abstractions.ITimesheetStatusBL
    {
        private ITimesheetStatusRepository timesheetStatusRepository;
        
        public TimesheetStatusBL(Abstractions.IMainService mainService)
            :base(mainService)
        {
            this.timesheetStatusRepository = mainService.Storage.GetRepository<ITimesheetStatusRepository>();
        }
        public List<TimesheetStatusDto> List()
        {
            return this.timesheetStatusRepository.List().Select(x => x.Convert()).ToList();
        }
    }
}
