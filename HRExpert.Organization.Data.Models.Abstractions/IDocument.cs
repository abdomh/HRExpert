using System;

namespace HRExpert.Organization.Data.Models.Abstractions
{
    using Core.Data.Models.Abstractions;    
    public interface IDocument : IEntity<long>
    {
        Guid DocumentGuid { get; set; }
    }
}
