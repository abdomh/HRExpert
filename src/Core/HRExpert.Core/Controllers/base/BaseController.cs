using HRExpert.Core.BL.Abstractions;
using Microsoft.AspNet.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HRExpert.Core.Controllers
{
    public class BaseController : Controller
    {
        #region Private
        private IBaseBL baseBl;
        #endregion
        #region Public
        public IBaseBL BaseBl
        { get { return baseBl; } }
        #endregion
        #region Ctor
        public BaseController(
            IBaseBL baseBL
            )
        {
            this.baseBl = baseBL;
        }
        #endregion 

    }
}
