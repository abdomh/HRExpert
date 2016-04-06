using System.Linq;
using System.Collections.Generic;
using ExtCore.Data.Abstractions;
using HRExpert.Core.Data.Abstractions;
using HRExpert.Core.Data.Models;
using HRExpert.Core.DTO;
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
        #region Public
        #region Converters
        public override IdNameDto ToDto(User entity)
        {
            UserDto result = new UserDto();
            result.Id = entity.Id; 
            result.Name = entity.Name;
            result.Roles = entity.Roles?.Select(x => new RoleDto { Id=x.Role.Id, Name = x.Role.Name } ).ToList();
            return result;
        }
        public override void FromDto(User entity, IdNameDto indto)        
        {
            var dto = (UserDto)indto;
            entity.Name = dto.Name; 
            var toDelete = entity.Roles.Where(x => !dto.Roles.Any(y => y.Id == x.RoleId)).ToList();
            foreach (var del in toDelete)
                entity.Roles.Remove(del);
            var newRoles = dto.Roles.Where(x => !entity.Roles.Any(y => y.RoleId == x.Id)).ToList();
            foreach (var role in newRoles)
            {
                var roleEntity = RoleRepository.Read(role.Id);
                entity.Roles.Add(new RoleUser { Role = roleEntity, RoleId = roleEntity.Id, User = entity, UserId = entity.Id });
            }            
        }
        #endregion
        #endregion
    }
}
