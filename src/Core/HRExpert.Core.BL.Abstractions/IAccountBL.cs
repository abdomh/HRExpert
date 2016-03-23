using HRExpert.Core.DTO;
using HRExpert.Core.DTO.ViewModels.Account;
using Microsoft.AspNet.Http;
namespace HRExpert.Core.BL.Abstractions
{
    public interface IAccountBL
    {
        SignInViewModel GetSignIn();
        RegisterViewModel GetRegister();

        UserDto SignIn(HttpContext context, SignInViewModel viewModel);
        UserDto Register(RegisterViewModel viewModel);
    }
}
