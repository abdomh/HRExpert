using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExtCore.Data.Abstractions;
using Platformus.Barebone.ViewComponents;
using Microsoft.AspNetCore.Mvc;
namespace HRExpert.Organization.ViewComponents
{
    using ViewModels;
    using BL.Abstractions;
    public class PersonSelectViewComponent : ViewComponent
    {
        IPersonBL personBL;

        public PersonSelectViewComponent(IPersonBL personBL) 
        {
            this.personBL = personBL;
        }
        public async Task<IViewComponentResult> InvokeAsync(string fieldname)
        {
            List<IdNameViewModel> options = personBL.List().Select(x => new IdNameViewModel { Id = x.Id, Name = x.Name }).ToList();
            PersonSelectViewModel model = new PersonSelectViewModel { FieldName = fieldname, SelectOptions = options };
            return this.View(model);
        }
    }
}
