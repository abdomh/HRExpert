using System.Linq;
using Microsoft.Data.Entity;
using HRExpert.Organization.Data.Abstractions;
using HRExpert.Core.Data.EntityFramework.SqlServer.Repository.Base;
using HRExpert.Organization.Data.Models;
namespace HRExpert.Organization.Data.EntityFramework.SqlServer.Repository
{
    public class PositionRepository : ReferencyRepositoryBase<Position>, IPositionRepository
    {
    }
}
