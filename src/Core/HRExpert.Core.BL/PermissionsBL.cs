using ExtCore.Data.Abstractions;
using HRExpert.Core.Data.Abstractions;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Services.Abstractions;
using HRExpert.Core.DTO;
namespace HRExpert.Core.BL
{
    public class PermissionsBL : ReferencyBl<PermissionType>, Abstractions.IPermissionBL
    {
        #region Ctor
        public PermissionsBL(IStorage storage, IAuthService authService)
            : base(storage, authService)
        {
            var repository = storage.GetRepository<IPermissionTypesRepository>();
            this.SetRepository(repository);
        }
        #endregion        
        #region Public
        #region Converters
        public override IdNameDto ToDto(PermissionType entity)
        {
            PermissionDto result = new PermissionDto();
            result.Id = entity.Id;
            result.Name = entity.Name;
            if (entity.Section != null)
            {
                result.Section = new SectionDto { Id = entity.Section.Id, Name = entity.Section.Name };
            }
            return result;
        }
        public override void FromDto(PermissionType entity, IdNameDto indto)
        {
            var dto = (PermissionDto)indto;
            entity.Name = dto.Name;
            entity.Section = SectionRepository.Read(dto.Section.Id);
        }
        #endregion
        #endregion
    }
}
