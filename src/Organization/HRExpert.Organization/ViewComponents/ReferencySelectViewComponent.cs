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
    public class ReferencySelectViewComponent : ViewComponent
    {
        private IReferenceBL referenceBL;
        public ReferencySelectViewComponent(IReferenceBL referenceBL)
        {
            this.referenceBL = referenceBL;
        }
        public async Task<IViewComponentResult> InvokeAsync(string referenceName , string fieldname, bool isEditable=true, int currentValue = 0)
        {
            List<IdNameViewModel> options = referenceBL.List(referenceName).Select(x=>new IdNameViewModel { Id = x.Id, Name = x.Name }).ToList();
            ReferencySelectViewModel model = new ReferencySelectViewModel { FieldName = fieldname, SelectOptions = options };
            model.IsEditable = isEditable;
            model.CurrentValue = currentValue;
            return this.View(model);
        }
    }
}
