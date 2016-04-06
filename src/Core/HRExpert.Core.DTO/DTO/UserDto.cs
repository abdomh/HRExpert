using System;
using System.Collections.Generic;
using HRExpert.Core.Abstractions.Enum;
using HRExpert.Core.Abstractions;
namespace HRExpert.Core.DTO
{
    public class UserDto : IdNameDto, IUser
    {        
        public UserDto()
        {
            this.Roles = new List<RoleDto>();
        }
        public List<RoleDto> Roles { get; set; }
    }
}
