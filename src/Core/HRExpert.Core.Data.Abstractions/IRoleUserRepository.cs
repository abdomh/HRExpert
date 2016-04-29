using System.Collections.Generic;
using HRExpert.Core.Data.Models;

namespace HRExpert.Core.Data.Abstractions
{
    /// <summary>
    /// Репозиторий связи пользователей и ролей
    /// </summary>
    public interface IRoleUserRepository:ExtCore.Data.Abstractions.IRepository
    {
        /// <summary>
        /// Список по пользователю
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        List<RoleUser> ListByUser(long userid);
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="entity"></param>
        void Create(RoleUser entity);
        /// <summary>
        /// удаление
        /// </summary>
        /// <param name="entity"></param>
        void Delete(RoleUser entity);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="roleid"></param>
        void Delete(long userid, long roleid);
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="roleid"></param>
        /// <returns></returns>
        RoleUser Read(long userid, long roleid);
    }
}