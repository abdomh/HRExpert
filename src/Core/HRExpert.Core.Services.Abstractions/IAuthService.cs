using Microsoft.AspNet.Http;
using HRExpert.Core.Data.Models.Abstractions;
namespace HRExpert.Core.Services.Abstractions
{
    public interface IAuthService
    {
        HttpContext CurrentContext { get; set; }
        void SignIn(IUser user);
        void SignOut();
    }
}
