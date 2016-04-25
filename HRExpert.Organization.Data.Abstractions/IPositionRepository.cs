using System.Collections.Generic;
using HRExpert.Organization.Data.Models;
namespace HRExpert.Organization.Data.Abstractions
{
    /// <summary>
    /// Репозиторий должностей
    /// </summary>
    public interface IPositionRepository : ExtCore.Data.Abstractions.IRepository
    {
        /// <summary>
        /// Все должности
        /// </summary>
        /// <returns></returns>
        IEnumerable<Position> All();
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="entity"></param>
        void Create(Position entity);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="Id"></param>
        void Delete(long Id);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="entity"></param>
        void Delete(Position entity);
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Position Read(long Id);
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="entity"></param>
        void Update(Position entity);
    }
}
