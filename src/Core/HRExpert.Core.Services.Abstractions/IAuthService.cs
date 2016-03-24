using Microsoft.AspNet.Http;
using HRExpert.Core.Abstractions;
namespace HRExpert.Core.Services.Abstractions
{
    public interface IAuthService
    {
        HttpContext CurrentContext { get;}
        IUser CurrentUser { get; }
        void SetCurrentContext(HttpContext context);
        void SignIn(IUser user);
        void SignOut();
        void ChangeAccount(IUser user);
    }
}
