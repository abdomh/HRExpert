using System.Collections.Generic;
using HRExpert.Organization.DTO;
namespace HRExpert.Organization.BL.Abstractions
{
    /// <summary>
    /// Бизнес логика персонажей
    /// </summary>
    public interface IPersonBL
    {
        /// <summary>
        /// Все сотрудники
        /// </summary>
        /// <returns></returns>
        List<PersonDto> List();
        /// <summary>
        /// Сотрудник по Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        PersonDto Read(long Id);
        /// <summary>
        /// Все по штатной единице
        /// </summary>
        /// <param name="DepartmentId"></param>
        /// <param name="PositionId"></param>
        /// <returns></returns>
        List<PersonDto> GetByStaffEstablishedPost(long OrganizationId,long DepartmentId, long PositionId);
        /// <summary>
        /// Персонаж по штатной единице и идентификатору
        /// </summary>
        /// <param name="OrganizationId"></param>
        /// <param name="DepartmentId"></param>
        /// <param name="PositionId"></param>
        /// <param name="PersonId"></param>
        /// <returns></returns>
        PersonDto GetByStaffEstablishedPostAndId(long OrganizationId, long DepartmentId, long PositionId, long PersonId);

        void Create(PersonDto dto);
    }
}
