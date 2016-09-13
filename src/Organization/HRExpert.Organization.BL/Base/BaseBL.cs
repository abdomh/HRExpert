using System;
using Platformus.Barebone;
namespace HRExpert.Organization.BL
{
    public class BaseBL: Abstractions.IBaseBl
    {
        protected Abstractions.IMainService MainService;
        public BaseBL(Abstractions.IMainService mainService)
        {
            this.MainService = mainService;
        }     
    }
}
