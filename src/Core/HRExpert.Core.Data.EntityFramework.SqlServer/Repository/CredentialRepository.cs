using System.Linq;
using Microsoft.Data.Entity;
using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Data.Abstractions;

namespace HRExpert.Core.Data.EntityFramework.SqlServer.Repository
{
    public class CredentialRepository: RepositoryBase<Credential>, ICredentialRepository
    {
        public Credential GetByValueTypeCodeAndSecret(string Value, string TypeCode, string Secret)
        {            
            return this.dbSet
                .Include(x=>x.User)
                .Include(x=>x.CredentialType)
                .FirstOrDefault(x => x.Value == Value && x.CredentialType.Code == TypeCode && x.Secret == Secret );            
        }
        public Credential GetByValueAndSecret(string Value, string Secret)
        {
            return this.dbSet
                .Include(x => x.User)
                .Include(x => x.CredentialType)
                .FirstOrDefault(x => x.Value == Value && x.Secret == Secret);
        }
    }
}
