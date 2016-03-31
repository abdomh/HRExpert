using ExtCore.Data.Abstractions;
using HRExpert.Core.Data.Abstractions;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Services.Abstractions;
namespace HRExpert.Core.BL
{
    public class UsersBL: ReferencyBl<User>, Abstractions.IUsersBL
    {
        #region Ctor
        public UsersBL(IStorage storage,IAuthService authService)
            :base(storage,authService)
        {
            var repository = storage.GetRepository<IUserRepository>();
            this.SetRepository(repository);
        }
        #endregion
    }
}
