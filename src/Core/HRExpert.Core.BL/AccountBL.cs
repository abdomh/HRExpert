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
            :base(authService)
        {
            this.storage = storage;
            this.userRepository = storage.GetRepository<IUserRepository>();
        }
        #endregion
        #region Private 
        private IStorage storage;
        private IUserRepository userRepository;
        
        private UserDto Convert(User user)
        {
            UserDto result = new UserDto
            {
                Id = user.Id,
                Name = user.Object.Name
            };
            return result;
        }
        #endregion
        #region Public
        public SignInViewModel GetSignIn() => new SignInViewModel();
        public RegisterViewModel GetRegister() => new RegisterViewModel();

        public UserDto SignIn(SignInViewModel viewModel)
        {
            var user = userRepository.GetByLoginAndSecret(viewModel.Login, viewModel.Password);
            if (user == null) return null;
            var dto = Convert(user);
            AuthService.SignIn(dto);
            return dto;
        }
        public UserDto Register(RegisterViewModel viewModel)
        {
            var user = userRepository.Create(viewModel.Name, viewModel.Email, viewModel.Password);
            return user != null ?
                null
                : Convert(user);
        }
        #endregion
    }
}
