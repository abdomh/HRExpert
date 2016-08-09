using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRExpert.Core.Data.Models;
using HRExpert.Core.DTO;
namespace HRExpert.Core.BL.Converters
{
    public static class Converter
    {
        public static SectionDto Convert(this Section entity)
        {
            if (entity == null) return null;
            SectionDto dto = new SectionDto();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Route = entity.RouteName;            
            return dto;
        }
        public static PermissionDto Convert(this PermissionType entity)
        {
            if (entity == null) return null;
            PermissionDto dto = new PermissionDto();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Section = entity.Section.Convert();
            return dto;          
        }
        public static UserDto Convert(this User entity)
        {
            if (entity == null) return null;
            UserDto dto = new UserDto();
            dto.Name = entity.Name;
            dto.Id = entity.Id;
            dto.Roles = entity.Roles?.Select(x => x.Role.Convert()).ToList();
            dto.Credentials = entity.Credentials?.Select(x => x.Convert()).ToList();
            return dto;
        }
        public static RoleDto Convert(this Role entity)
        {
            if (entity == null) return null;
            RoleDto dto = new RoleDto();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            return dto;
        }
        public static CredentialTypeDto Convert( this CredentialType entity)
        {
            if (entity == null) return null;
            CredentialTypeDto dto = new CredentialTypeDto();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            return dto;
        }
        public static CredentialDto Convert(this Credential entity)
        {
            if (entity == null) return null;
            CredentialDto dto = new CredentialDto();
            dto.Secret = entity.Secret;
            dto.Value = entity.Value;
            dto.Type = entity.CredentialType.Convert();
            return dto;
        }

    }
}
