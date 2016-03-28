using HRExpert.Core.Data.Models;
namespace HRExpert.Core.Data.Abstractions
{
    public interface IUserRepository: IReferencyRepository<User>
    {        
        User Create(string Name, string Email, string Password);
    }
}
