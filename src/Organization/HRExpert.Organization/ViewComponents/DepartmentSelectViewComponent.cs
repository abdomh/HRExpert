using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExtCore.Data.Abstractions;
using Platformus.Barebone.ViewComponents;
using Microsoft.AspNetCore.Mvc;
namespace HRExpert.Organization.ViewComponents
{
    using BL.Abstractions;
    using ViewModels;
    public class DepartmentSelectViewComponent: ViewComponent
    {
        
        IDepartmentBL departmentBL;

        public DepartmentSelectViewComponent(IDepartmentBL departmentBL)
        {
            this.departmentBL = departmentBL;
        }
        public async Task<IViewComponentResult> InvokeAsync(string DepartmentIdField, string DepartmentNameField)
        {
            var departments = departmentBL.List().Select(x=>new TreeElementViewModel { id = x.Id, text = x.Name, parentId = x.ParentId });
            foreach(var element in departments)
            {
                element.children = departments.Where(x => x.parentId == element.id);
            }
            TreeViewModel model = new TreeViewModel { };
            return this.View(model);
        }
    }
}
