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
        /// Подразделения для пользователя
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        IEnumerable<Department> GetDepartmentsForUser(int UserId);
        /// <summary>
        /// Все подразделения по Id организации
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        IEnumerable<Department> AllByOrganization(int Id);
        /// <summary>
        /// Подразделение по организации и идентификатору
        /// </summary>
        /// <param name="organizationid"></param>
        /// <param name="departmentid"></param>
        /// <returns></returns>
        Department ByOrganizationAndKey(int organizationid, int departmentid);
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
        void Delete(int Id);
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
        Department Read(int Id);
        /// <summary>
        /// Чтение с дочерними и родительскими подразделениями
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Department ReadWithChildsAndParents(int Id);
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="entity"></param>
        void Update(Department entity);

    }
}
