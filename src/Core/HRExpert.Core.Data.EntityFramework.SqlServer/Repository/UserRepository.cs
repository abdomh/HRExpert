using System.Linq;
using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Data.Abstractions;

namespace HRExpert.Core.Data.EntityFramework.SqlServer.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {        
        public User Create(string Name, string Email, string Password)
        {
            User entity = new User();
            Credential EmailCredential = new Credential();
            Credential NameCredential = new Credential();            
                        
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }
    }
}
