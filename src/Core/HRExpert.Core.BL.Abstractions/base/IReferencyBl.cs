using System.Collections.Generic;
using HRExpert.Core.DTO;
namespace HRExpert.Core.BL.Abstractions
{
    public interface IReferencyBl
    {
        IdNameDto Create(IdNameDto dto);
        IEnumerable<IdNameDto> List();
        IdNameDto Read(long id);
        IdNameDto Update(IdNameDto dto);
        IdNameDto Delete(long id);
    }
}