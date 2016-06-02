using System;

namespace HRExpert.Organization.Data.Models.Abstractions
{
    public interface IDocument : ExtCore.Data.Models.Abstractions.IEntity
    {
        Guid DocumentGuid { get; set; }
    }
}
