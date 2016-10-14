using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using HRExpert.Organization.DTO;
using HRExpert.Organization.BL.Abstractions;
using ExtCore.Data.Abstractions;

namespace HRExpert.Organization.Controllers
{
    using ViewModels;
    public class CalendarController: Platformus.Barebone.Controllers.ControllerBase
    {
        private IPersonEventBL personEventBL;
        public CalendarController(IStorage storage, IPersonEventBL personEventBL)
            :base(storage)
        {
            this.personEventBL = personEventBL;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = new CalendarViewModel();

            return View(model);
        }
        public List<CalendarDto> GetData(DateTime start, DateTime end)
        {
            return this.personEventBL.GetPersonEvents(start,end);
        }
    }
}
