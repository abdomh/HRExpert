using System;
using HRExpert.Organization.Data.Models;
using ExtCore.Data.Abstractions;
using HRExpert.Organization.Data.Abstractions;
using HRExpert.Organization.DTO;
using System.Collections.Generic;
using System.Linq;
using Platformus.Barebone;
using Platformus.Security;

namespace HRExpert.Organization.BL
{
    public class PersonEventBL: BaseBL, Abstractions.IPersonEventBL
    {
        private IPersonEventsRepository personEventRepository;

        public PersonEventBL(Abstractions.IMainService mainService)
            :base(mainService)
        {
            this.personEventRepository = mainService.Storage.GetRepository<IPersonEventsRepository>();
        }
        public List<CalendarDto> GetPersonEvents(DateTime start, DateTime end)
        {
            var events = this.personEventRepository.GetPersonEvents(MainService.CurrentUserId, start, end );
            return events?.Select(x => new CalendarDto()
            {
                backgroundColor = DocumentColorConstants.ByCode[x.Document.DocumentType.Code],
                borderColor = DocumentColorConstants.ByCode[x.Document.DocumentType.Code],
                title = x.Timesheet.Status?.ShortName + " " + x.Document.Person.Name + " : " + x.Document.DocumentType.Name,
                description = x.Document.Person.Name + " : " + x.Document.DocumentType.Name
                                + (x.BeginDate.HasValue ? " c " + x.BeginDate.Value.ToString("dd.MM.yyyy") : "")
                                + (x.EndDate.HasValue ? " по " + x.EndDate.Value.ToString("dd.MM.yyyy") : ""),
                id = x.DocumentGuid.ToString(),
                start = x.BeginDate,
                end =x.EndDate }).ToList();
        }
        
    }
}
