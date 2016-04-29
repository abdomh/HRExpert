using System.Linq;
using System.Collections.Generic;
using HRExpert.Core.Data.Models;
namespace HRExpert.Core.Data.EntityFramework.SqlServer.Repository
{
    /// <summary>
    /// Репозиторий связи ролей и пользователей
    /// </summary>
    public class RoleUserRepository: ExtCore.Data.EntityFramework.SqlServer.RepositoryBase<RoleUser>, Abstractions.IRoleUserRepository
    {
        /// <summary>
        /// Чтение по пользователю и роли
        /// </summary>
        /// <param name="userid">идентификатор пользователя</param>
        /// <param name="roleid">идентификатор роли</param>
        /// <returns></returns>
        public virtual RoleUser Read(long userid,long roleid)
        {
            return this.dbSet.Where(x => x.UserId == userid && x.RoleId == roleid).FirstOrDefault();
        }
        public virtual List<RoleUser> ListByUser(long userid)
        {
            return this.dbSet.Where(x => x.UserId == userid).ToList();
        }
        /// <summary>
        /// Создание 
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Create(RoleUser entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="roleid"></param>
        public virtual void Delete(long userid, long roleid)
        {
            Delete(Read(userid, roleid));
        }
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Delete(RoleUser entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
