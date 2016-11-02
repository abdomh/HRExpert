using System;
using System.Collections.Generic;
using HRExpert.Organization.DTO;

namespace HRExpert.Organization.BL.Abstractions
{
    public interface IPersonEventBL: IBaseBl
    {
        List<CalendarDto> GetPersonEvents(DateTime start, DateTime end);
        List<CalendarDto> GetPersonEvents(int PersonId, DateTime start, DateTime end);
    }
}