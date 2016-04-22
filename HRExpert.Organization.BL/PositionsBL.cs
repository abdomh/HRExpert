using HRExpert.Organization.Data.Models;
using HRExpert.Core.Services.Abstractions;
using ExtCore.Data.Abstractions;
using HRExpert.Organization.Data.Abstractions;
namespace HRExpert.Organization.BL
{
    public class PositionsBL: Core.BL.ReferencyBl<Position>, Abstractions.IPositionsBL
    {
        public PositionsBL(IStorage storage, IAuthService authService)
           :base(storage, authService)
        {
            var positionRepository = storage.GetRepository<IPositionRepository>();
            this.SetRepository(positionRepository);
        }
    }
}
