using HRExpert.Core.Data.Models;
namespace HRExpert.Core.Data.Abstractions
{
    public interface IUserRepository: ExtCore.Data.Abstractions.IRepository
    {
        User GetByLoginAndSecret(string login, string secret);
        User Create(string Name, string Email, string Password);
    }
}
