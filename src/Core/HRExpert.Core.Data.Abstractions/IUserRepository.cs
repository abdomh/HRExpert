using HRExpert.Core.Data.Models;
namespace HRExpert.Core.Data.Abstractions
{
    public interface IUserRepository: ExtCore.Data.Abstractions.IRepository
    {        
        User Create(string Name, string Email, string Password);
    }
}
