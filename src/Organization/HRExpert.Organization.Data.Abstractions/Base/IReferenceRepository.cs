using System.Collections.Generic;
namespace HRExpert.Organization.Data.Abstractions
{
    using Models.Abstractions;
    public interface IReferenceRepository: Base.IRepository
    {
        List<IReference> GetReferencies();
    }
}
