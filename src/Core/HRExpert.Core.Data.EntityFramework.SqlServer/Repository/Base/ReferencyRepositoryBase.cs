using System.Linq;
using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Data.Models.Parent;
using HRExpert.Core.Data.Abstractions;

namespace HRExpert.Core.Data.EntityFramework.SqlServer.Repository.Base
{
    public class ReferencyRepositoryBase<T>: RepositoryBase<T> where T : Referency
    {
        public T GetByCode(string code)
        {
            return this.dbSet.FirstOrDefault(x => x.Code == code);
        }
    }
}
