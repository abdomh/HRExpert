using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Data.Abstractions;

namespace HRExpert.Core.Data.EntityFramework.SqlServer.Repository
{
    /// <summary>
    /// Хранилище пользователей
    /// </summary>
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        /// <summary>
        /// Все записи
        /// </summary>
        /// <returns>Коллекция записей</returns>
        public virtual IEnumerable<User> All()
        {
            return this.dbSet.ToList();
        }
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="entity">Сущность</param>
        public virtual void Create(User entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="Id">Идентификатор</param>
        /// <returns>Сущность</returns>
        public virtual User Read(long Id)
        {
            return this.dbSet.Where(x => x.Id == Id).FirstOrDefault();
        }
        /// <summary>
        /// Обновление/редактирование сущности
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Update(User entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Удаление по идентификатору
        /// </summary>
        /// <param name="Id">Идентификатор</param>
        public virtual void Delete(long Id)
        {
            this.Delete(this.Read(Id));
        }
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="entity">Сущность</param>
        public virtual void Delete(User entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Профиль пользователя
        /// </summary>
        /// <param name="Id">Идентификатор пользователя</param>
        /// <returns>Пользователь со всеми свойствами</returns>
        public User Profile(long Id)
        {
            return this.dbSet
                .Include(x => x.Credentials)
                .Include(x => x.Roles)
                    .ThenInclude(x => x.Role)
                        .ThenInclude(x => x.Permissions)
                            .ThenInclude(x => x.PermissionType)
                .Include(x=>x.Roles).ThenInclude(x=>x.Role).ThenInclude(x=>x.Sections).ThenInclude(x=>x.Section)
                .Where(x => x.Id == Id).FirstOrDefault();
        }
    }
}
