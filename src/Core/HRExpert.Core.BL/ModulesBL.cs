using ExtCore.Data.Abstractions;
using HRExpert.Core.Data.Abstractions;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Services.Abstractions;
namespace HRExpert.Core.BL
{
    public class ModulesBL : ReferencyBl<Module>, Abstractions.IModuleBL
    {
        #region Ctor
        public ModulesBL(IStorage storage, IAuthService authService)
            : base(storage, authService)
        {
            var repository = storage.GetRepository<IModuleRepository>();
            this.SetRepository(repository);
        }
        #endregion        
    }
}
