using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Data.Abstractions;

namespace HRExpert.Core.Data.EntityFramework.SqlServer.Repository
{
    /// <summary>
    /// Хранилище учётных данных
    /// </summary>
    public class CredentialRepository: RepositoryBase<Credential>, ICredentialRepository
    {
        /// <summary>
        /// Получение учётки по логину/паролю
        /// </summary>
        /// <param name="Value">Логин</param>
        /// <param name="Secret">Пароль</param>
        /// <returns>Учетные данные - если есть, null - если нет</returns>
        public Credential GetByValueAndSecret(string Value, string Secret)
        {
            return this.dbSet
                .Include(x => x.User)
                    .ThenInclude(x=>x.Roles)
                        .ThenInclude(x=>x.Role)                            
                            .ThenInclude(x=>x.Permissions)
                                .ThenInclude(x=>x.PermissionType)
                .Include(x=>x.User).ThenInclude(x=>x.Roles).ThenInclude(x=>x.Role).ThenInclude(x=>x.Sections).ThenInclude(x=>x.Section)
                .Include(x => x.CredentialType)
                .FirstOrDefault(x => x.Value == Value && x.Secret == Secret);
        }
        /// <summary>
        /// Все записи
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<Credential> All()
        {
            return this.dbSet
                .Include(x=>x.User)
                .ToList();
        }
        /// <summary>
        /// Создание сущности
        /// </summary>
        /// <param name="entity">сущность</param>
        public virtual void Create(Credential entity)
        {
            this.dbSet.Add(entity);
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Чтение сущности по ключу
        /// </summary>
        /// <param name="CredentialTypeId">Идентификатор типа</param>
        /// <param name="UserId">Идентификатор пользователя</param>
        /// <returns></returns>
        public virtual Credential Read(long CredentialTypeId,long UserId)
        {
            return this.dbSet
                .Include(x=>x.User)
                .Where(x => x.CredentialTypeId==CredentialTypeId && x.UserId==UserId).FirstOrDefault();
        }
        /// <summary>
        /// Обновление сущности
        /// </summary>
        /// <param name="entity">сущность</param>
        public virtual void Update(Credential entity)
        {
            this.dbContext.Entry(entity).State = EntityState.Modified;
            this.dbContext.SaveChanges();
        }
        /// <summary>
        /// Удаление по ключу
        /// </summary>
        /// <param name="CredentialTypeId">Идентификатор типа</param>
        /// <param name="UserId">Идентификатор пользователя</param>
        public virtual void Delete(long CredentialTypeId, long UserId)
        {
            this.Delete(this.Read(CredentialTypeId, UserId));
        }
        /// <summary>
        /// Удаление сущности
        /// </summary>
        /// <param name="entity">Сущность</param>
        public virtual void Delete(Credential entity)
        {
            this.dbSet.Remove(entity);
            this.dbContext.SaveChanges();
        }
    }
}
