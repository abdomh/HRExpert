using ExtCore.Data.Abstractions;
using HRExpert.Core.Data.Abstractions;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Services.Abstractions;
namespace HRExpert.Core.BL
{
    public class SectionsBL : ReferencyBl<Section>, Abstractions.ISectionBL
    {
        #region Ctor
        public SectionsBL(IStorage storage, IAuthService authService)
            : base(storage, authService)
        {
            var repository = storage.GetRepository<ISectionRepository>();
            this.SetRepository(repository);
        }
        #endregion        
    }
}
