using System.Linq;
using ExtCore.Data.Abstractions;
using HRExpert.Core.BL.Abstractions;
using HRExpert.Core.Data.Abstractions;
using HRExpert.Core.DTO;
using HRExpert.Core.DTO.ViewModels.Account;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Services.Abstractions;
namespace HRExpert.Core.BL
{
    public class AccountBL: BaseBL, IAccountBL
    {
        #region Ctor
        public AccountBL(IAuthService authService , IStorage storage)
            :base(storage , authService)
        {            
        }
        #endregion
        #region Private 
        
        private UserDto Convert(User user)
        {
            UserDto result = new UserDto
            {
                Id = user.Id,
                Name = user.Credentials.FirstOrDefault(x => x.CredentialType.Code == "0001").Value
            };
            return result;
        }
        #endregion
        #region Public
        public SignInViewModel GetSignIn() => new SignInViewModel();
        public RegisterViewModel GetRegister() => new RegisterViewModel();

        public UserDto SignIn(SignInViewModel viewModel)
        {
            var credential = CredentialRepository.GetByValueTypeCodeAndSecret(viewModel.Login, "0001", viewModel.Password);

            if (credential == null) return null;
            var dto = Convert(credential.User);
            AuthService.SignIn(dto);
            return dto;
        }
        public UserDto Register(RegisterViewModel viewModel)
        {
            var user = UserRepository.Create(viewModel.Name, viewModel.Email, viewModel.Password);
            return user != null ?
                null
                : Convert(user);
        }
        #endregion
    }
}
