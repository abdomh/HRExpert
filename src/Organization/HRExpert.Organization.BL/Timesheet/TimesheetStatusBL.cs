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
    public class TimesheetStatusBL: Abstractions.ITimesheetStatusBL
    {
        private ITimesheetStatusRepository timesheetStatusRepository;
        public TimesheetStatusBL(IHandler handler)
        {
            this.timesheetStatusRepository = handler.Storage.GetRepository<ITimesheetStatusRepository>();
        }
        public List<TimesheetStatusDto> List()
        {
            return this.timesheetStatusRepository.List().Select(x => x.Convert()).ToList();
        }
    }
}
