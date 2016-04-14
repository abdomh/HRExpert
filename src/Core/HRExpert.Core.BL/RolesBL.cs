using System.Linq;
using ExtCore.Data.Abstractions;
using HRExpert.Core.Data.Abstractions;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Services.Abstractions;
using HRExpert.Core.DTO;
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
        #region Public
        #region Converters
        public override IdNameDto ToDto(Role entity)
        {
            RoleDto result = new RoleDto();
            result.Id = entity.Id;
            result.Name = entity.Name;
            result.Permissions = entity.Permissions?.Select(x => new PermissionDto { Id = x.PermissionType.Id, Name = x.PermissionType.Name, Section = new SectionDto { Name = x.PermissionType.Section.Name, Id = x.PermissionType.Section.Id } }).ToList();
            return result;
        }
        public override void FromDto(Role entity, IdNameDto indto)
        {
            var dto = (RoleDto)indto;
            entity.Name = dto.Name;
            var toDelete = entity.Permissions?.Where(x => !dto.Permissions.Any(y => y.Id == x.PermissionTypeId))?.ToList();
            if(toDelete!=null)
            foreach (var del in toDelete)
                entity.Permissions.Remove(del);
            var newPermissions = dto.Permissions.Where(x => !entity.Permissions.Any(y => y.PermissionTypeId == x.Id)).ToList();
            foreach (var permission in newPermissions)
            {
                var permissionEntity = PermissionsRepository.Read(permission.Id);
                entity.Permissions.Add(new RolePermission { Role = entity, RoleId = entity.Id, PermissionType = permissionEntity, PermissionTypeId = permissionEntity.Id });
            }
        }
        #endregion
        #endregion   
    }
}
