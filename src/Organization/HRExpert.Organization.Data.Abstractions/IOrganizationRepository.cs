using System.Collections.Generic;
using HRExpert.Organization.Data.Models;
namespace HRExpert.Organization.Data.Abstractions
{
    /// <summary>
    /// Репозиторий организаций
    /// </summary>
    public interface IOrganizationRepository : ExtCore.Data.Abstractions.IRepository
    {
        /// <summary>
        /// Все организации
        /// </summary>
        /// <returns></returns>
        IEnumerable<Models.Organization> All();
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="entity"></param>
        void Create(Models.Organization entity);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="Id"></param>
        void Delete(int Id);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="entity"></param>
        void Delete(Models.Organization entity);
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Models.Organization Read(int Id);
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="entity"></param>
        void Update(Models.Organization entity);
    }
}
