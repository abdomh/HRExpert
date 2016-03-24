using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using HRExpert.Core.BL.Abstractions;
using HRExpert.Core.DTO.ViewModels.Account;
using HRExpert.Core.Abstractions.Enum;
namespace HRExpert.Core.Controllers
{
    [Authorize(Roles = RoleReferency.Administrator )]
    public class AdministrationController: Controller
    {
    }
}
