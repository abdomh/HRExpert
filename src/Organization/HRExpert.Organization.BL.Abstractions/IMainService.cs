using ExtCore.Data.Abstractions;
namespace HRExpert.Organization.BL.Abstractions
{
    public interface IMainService
    {
        bool IsUserLoggedIn { get; }
        int CurrentUserId { get; }
        IStorage Storage { get; }
    }
}
