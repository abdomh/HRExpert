using System.Collections.Generic;
using HRExpert.Organization.Data.Models.Abstractions;

namespace HRExpert.Organization.BL.Abstractions
{
    public interface IReferenceBL
    {
        List<IReference> List(string referenceName);
    }
}