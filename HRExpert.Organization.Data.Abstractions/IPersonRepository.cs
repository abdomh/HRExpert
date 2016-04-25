using HRExpert.Core.Data.Abstractions;
using HRExpert.Organization.Data.Models;
using System.Collections.Generic;
namespace HRExpert.Organization.Data.Abstractions
{
    public interface IPersonRepository : ExtCore.Data.Abstractions.IRepository
    {
        /// <summary>
        /// Все по штатной единице
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <param name="PositionId"></param>
        /// <returns></returns>
        List<Person> GetByStaffEstablishedPost(long DepartmentId, long PositionId);
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
