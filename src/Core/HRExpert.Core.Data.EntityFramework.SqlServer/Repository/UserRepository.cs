using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Data.Abstractions;

namespace HRExpert.Core.Data.EntityFramework.SqlServer.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public User GetByLoginAndSecret(string login, string secret)
        {
            return this.dbSet
                .Where(x => x.Email == login && x.Password == secret)?
                .First();
        }
        public User Create(string Name, string Email, string Password)
        {
            User entity = new User();
            entity.Email = Email;
            entity.Password = Password;
            entity.Object.Name = Name;
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
            return entity;
        }
    }
}
