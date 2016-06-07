using HRExpert.Core.Data.Abstractions;
using HRExpert.Organization.Data.Models;
using System.Collections.Generic;
namespace HRExpert.Organization.Data.Abstractions
{
    public interface IPersonRepository : HRExpert.Core.Data.Abstractions.IRepositoryWithPermissions
    {
        /// <summary>
        /// Получение сотрудника по идентификатору пользователя привязанного к подразделению
        /// </summary>
        /// <param name="UserId"></param>
        /// <param name="TargetDepartmentId"></param>
        /// <returns></returns>
        Person GetPersonByUserIdAndTargetDepartment(long UserId, long TargetDepartmentId);
        /// <summary>
        /// Все по штатной единице
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <param name="PositionId"></param>
        /// <returns></returns>
        List<Person> GetByStaffEstablishedPost(long OrganizationId, long DepartmentId, long PositionId);
        /// <summary>
        /// Персонаж по организацииб подразделению, должности и Id
        /// </summary>
        /// <param name="OrganizationId"></param>
        /// <param name="DepartmentId"></param>
        /// <param name="PositionId"></param>
        /// <param name="PersonId"></param>
        /// <returns></returns>
        Person GetByStaffEstablishedPostAndId(long OrganizationId, long DepartmentId, long PositionId, long PersonId);
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
        void Delete(long Id);
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
        Person Read(long Id);
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="entity"></param>
        void Update(Person entity);
    }
}
