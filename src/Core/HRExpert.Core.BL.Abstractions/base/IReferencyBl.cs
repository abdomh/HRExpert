using System.Collections.Generic;
using HRExpert.Core.Abstractions;
using HRExpert.Core.Data.Models.Parent;
using HRExpert.Core.DTO;
namespace HRExpert.Core.BL.Abstractions
{
    public interface IReferencyBl
    {
        void Create(IdNameDto dto);
        IEnumerable<IdNameDto> List();
        IdNameDto Read(long id);
        void Update(IdNameDto dto);
    }
}