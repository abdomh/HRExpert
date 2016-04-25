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
        List<PersonDto> GetByStaffEstablishedPost(long DepartmentId, long PositionId);
        void Create(PersonDto dto);
    }
}
