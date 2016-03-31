using ExtCore.Data.Abstractions;
using HRExpert.Core.Data.Abstractions;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Services.Abstractions;
namespace HRExpert.Core.BL
{
    public class RolesBL: ReferencyBl<Role>, Abstractions.IRoleBL
    {
        #region Ctor
        public RolesBL(IStorage storage,IAuthService authService)  
            :base(storage,authService)          
        {
            var repository = storage.GetRepository<IRoleRepository>();
            this.SetRepository(repository);
        }
        #endregion        
    }
}
