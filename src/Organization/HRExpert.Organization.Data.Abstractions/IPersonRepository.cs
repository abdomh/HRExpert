using HRExpert.Organization.Data.Models;
using System.Collections.Generic;
namespace HRExpert.Organization.Data.Abstractions
{
    public interface IPersonRepository : Base.IRepositoryWithPermissions
    {
        Person GetByUserId(int UserId);
        Person GetCurrentPerson();
        List<Person> GetPersonsByPermissions();
        /// <summary>
        /// Получение сотрудника по идентификатору пользователя привязанного к подразделению
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="TargetDepartmentId"></param>
        /// <returns></returns>
        Person GetPersonByUserIdAndTargetDepartment(int UserId, int TargetDepartmentId);
        /// <summary>
        /// Все по штатной единице
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <param name="PositionId"></param>
        /// <returns></returns>
        List<Person> GetByStaffEstablishedPost(int OrganizationId, int DepartmentId, int PositionId);
        /// <summary>
        /// Персонаж по организацииб подразделению, должности и Id
        /// </summary>
        /// <param name="OrganizationId"></param>
        /// <param name="DepartmentId"></param>
        /// <param name="PositionId"></param>
        /// <param name="PersonId"></param>
        /// <returns></returns>
        Person GetByStaffEstablishedPostAndId(int OrganizationId, int DepartmentId, int PositionId, int PersonId);
        /// <summary>
        /// Все организации
        /// </summary>
        /// <returns></returns>
        IEnumerable<Person> All();
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="entity"></param>
        void Create(Person entity);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="Id"></param>
        void Delete(int Id);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="entity"></param>
        void Delete(Person entity);
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Person Read(int Id);
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="entity"></param>
        void Update(Person entity);
    }
}
