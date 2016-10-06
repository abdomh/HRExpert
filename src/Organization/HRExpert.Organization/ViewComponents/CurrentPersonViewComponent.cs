using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExtCore.Data.Abstractions;
using Platformus.Barebone.ViewComponents;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
namespace HRExpert.Organization.ViewComponents
{
    using BL.Abstractions;
    using ViewModels;
    using Platformus.Security;
    public class CurrentPersonViewComponent: ViewComponent
    {
        IPersonBL personBL;
        IMainService mainService;
        public CurrentPersonViewComponent(IPersonBL personBL, IMainService mainService)
        {
            this.personBL = personBL;
            this.mainService = mainService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            UserManager userManager = new UserManager(mainService);
            var User = userManager.GetCurrentUser();
            if (User == null) return null;
            var Person = personBL.GetCurrentPerson();
            CurrentPersonViewModel model = new CurrentPersonViewModel();
            model.Name = Person.Name;
            model.Links.Add(new LinkViewModel { Name = "Выход", Ref = "/frontend/Account/SignOut" });
            return this.View(model);
        }
    }
}
