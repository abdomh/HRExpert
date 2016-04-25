using System.Collections.Generic;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.Abstractions
{
    /// <summary>
    /// Репозиторий штатных единиц
    /// </summary>
    public interface IStaffEstablishedPostRepository :ExtCore.Data.Abstractions.IRepository
    {
        /// <summary>
        /// Все по подразделению
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <returns></returns>
        List<StaffEstablishedPost> GetByDepartmentId(long DepartmentId);
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="entity"></param>
        void Create(StaffEstablishedPost entity);
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <param name="PositionId"></param>
        /// <returns></returns>
        StaffEstablishedPost Read(long DepartmentId, long PositionId);
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="entity"></param>
        void Update(StaffEstablishedPost entity);      
    }
}