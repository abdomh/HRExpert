using System.Collections.Generic;
using HRExpert.Organization.Data.Models;
namespace HRExpert.Organization.Data.Abstractions
{
    /// <summary>
    /// Репозиторий подразделений
    /// </summary>
    public interface IDepartmentRepository: ExtCore.Data.Abstractions.IRepository
    {
        /// <summary>
        /// Все подразделения по Id организации
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        IEnumerable<Department> AllByOrganization(long Id);
        /// <summary>
        /// Все подразделения
        /// </summary>
        /// <returns></returns>
        IEnumerable<Department> All();
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="entity"></param>
        void Create(Department entity);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="Id"></param>
        void Delete(long Id);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="entity"></param>
        void Delete(Department entity);
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Department Read(long Id);
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="entity"></param>
        void Update(Department entity);

    }
}
