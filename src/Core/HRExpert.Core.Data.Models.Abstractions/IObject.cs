using System;
namespace HRExpert.Core.Data.Models.Abstractions
{
    public interface IObject
    {
        string Name { get; set; }
        string Description { get; set; }
        DateTime? CreateDate { get; set; }
        DateTime? DeleteDate { get; set; }
    }
}
