using HRExpert.Core.DTO;
using HRExpert.Core.DTO.ViewModels.Account;
namespace HRExpert.Core.BL.Abstractions
{
    public interface IAccountBL
    {
        SignInViewModel GetSignIn();
        RegisterViewModel GetRegister();

        UserDto SignIn(SignInViewModel viewModel);
        UserDto Register(RegisterViewModel viewModel);
    }
}
