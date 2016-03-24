using System;
using HRExpert.Core.Abstractions.Enum;
using HRExpert.Core.Abstractions;
namespace HRExpert.Core.DTO
{
    public class UserDto : IdNameDto, IUser
    {
        public RolesEnum Role
        {
            get; set;
        }
    }
}
