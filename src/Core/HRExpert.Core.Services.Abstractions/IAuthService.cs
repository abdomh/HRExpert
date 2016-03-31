using Microsoft.AspNet.Http;
using HRExpert.Core.Data.Models;
namespace HRExpert.Core.Services.Abstractions
{
    public interface IAuthService
    {
        HttpContext CurrentContext { get;}
        User CurrentUser { get; }
        void SetCurrentContext(HttpContext context);
    }
}
