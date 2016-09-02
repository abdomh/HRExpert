using System.Collections.Generic;
using HRExpert.Organization.DTO;
using HRExpert.Organization.Data.Models;
namespace HRExpert.Organization.BL.Abstractions
{
    public interface IPositionsBL
    {
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        PositionDto Create(PositionDto dto);
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PositionDto Read(int id);
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        PositionDto Update(PositionDto dto);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PositionDto Delete(int id);
        /// <summary>
        /// Все
        /// </summary>
        /// <returns></returns>
        IEnumerable<PositionDto> List();
    }
}
