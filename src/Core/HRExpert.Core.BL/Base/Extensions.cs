using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRExpert.Core.Abstractions;
using HRExpert.Core.Data.Models.Parent;
using HRExpert.Core.DTO;
namespace HRExpert.Core.BL
{
    public static class Extensions
    {
        public static IIdName ToDto(this Referency entity)
        {
            IIdName result = new IdNameDto { Id = entity.Id, Name = entity.Name };
            return result;
        }
        public static T FromDto<T>(this T entity, IIdName dto) where T: Referency
        {
            entity.Name = dto.Name;
            return entity;
        }
    }
}
