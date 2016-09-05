using System.Collections.Generic;
using HRExpert.Organization.DTO;
namespace HRExpert.Organization.BL.Abstractions
{
    /// <summary>
    /// Бизнес логика организаций
    /// </summary>
    public interface IOrganizationBL : IBaseBl
    {
        /// <summary>
        /// Создание
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        OrganizationDto Create(OrganizationDto dto);
        /// <summary>
        /// Чтение
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OrganizationDto Read(int id);
        /// <summary>
        /// Обновление
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        OrganizationDto Update(OrganizationDto dto);
        /// <summary>
        /// Удаление
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        OrganizationDto Delete(int id);
        /// <summary>
        /// Все
        /// </summary>
        /// <returns></returns>
        IEnumerable<OrganizationDto> List();        
    }
}
