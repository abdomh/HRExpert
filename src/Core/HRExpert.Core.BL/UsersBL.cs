using ExtCore.Data.Abstractions;
using HRExpert.Core.Data.Abstractions;
using HRExpert.Core.Data.Models;
namespace HRExpert.Core.BL
{
    public class UsersBL: ReferencyBl<User>, Abstractions.IUsersBL
    {
        #region Ctor
        public UsersBL(IStorage storage)
        {
            var repository = storage.GetRepository<IUserRepository>();
            this.SetRepository(repository);
        }
        #endregion
    }
}
