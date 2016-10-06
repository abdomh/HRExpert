using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExtCore.Data.Abstractions;
using Platformus.Barebone.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using HRExpert.Organization.DTO;
namespace HRExpert.Organization.ViewComponents
{
    public class ApprovementViewComponent: ViewComponent
    {      
        public async Task<IViewComponentResult> InvokeAsync(string label, DocumentApprovementDto model)
        {            
            return this.View(model);
        }
    }
}
