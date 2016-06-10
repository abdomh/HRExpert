using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace HRExpert.Core.Data.EntityFramework.SqlServer.Repository
{
    public class RepositoryWithPersmissions<T>: ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<T> where T: class,ExtCore.Data.Models.Abstractions.IEntity
    {
        public RepositoryWithPersmissions()
            :base()
        {
        }

        public long CurrentUserId { get; set; }
        public long CurrentRoleId { get; set; }
        
    }
}
