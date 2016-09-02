using System;

namespace HRExpert.Organization.Data.Models.Abstractions
{ 
    public interface IDocument : IEntity<int>
    {
        Guid DocumentGuid { get; set; }
    }
}
