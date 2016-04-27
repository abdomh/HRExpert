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
