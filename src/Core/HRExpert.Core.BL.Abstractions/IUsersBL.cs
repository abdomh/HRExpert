using HRExpert.Core.DTO;
namespace HRExpert.Core.BL.Abstractions
{
    public interface IUsersBL: IReferencyBl
    {
        ProfileDto Profile();
    }
}
