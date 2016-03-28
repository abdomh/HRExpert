using ExtCore.Data.Abstractions;
using HRExpert.Core.Data.Abstractions;
using HRExpert.Core.Data.Models;
namespace HRExpert.Core.BL
{
    public class RolesBL: ReferencyBl<Role>, Abstractions.IRoleBL
    {
        #region Ctor
        public RolesBL(IStorage storage)            
        {
            var repository = storage.GetRepository<IRoleRepository>();
            this.SetRepository(repository);
        }
        #endregion        
    }
}
