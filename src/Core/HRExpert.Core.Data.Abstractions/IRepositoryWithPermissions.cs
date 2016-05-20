using System;
using System.Linq.Expressions;

namespace HRExpert.Core.Data.Abstractions
{
    public interface IRepositoryWithPermissions : ExtCore.Data.Abstractions.IRepository
    {
        long CurrentUserId { get; set; }
        long CurrentRoleId { get; set; }
    }
}
