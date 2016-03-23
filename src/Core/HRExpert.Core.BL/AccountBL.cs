using ExtCore.Data.Abstractions;
using HRExpert.Core.BL.Abstractions;
using HRExpert.Core.Data.Abstractions;
using HRExpert.Core.DTO;
using HRExpert.Core.DTO.ViewModels.Account;
using HRExpert.Core.Data.Models;
using System.Security.Claims;
using Microsoft.AspNet.Authentication.Cookies;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Http;

namespace HRExpert.Core.BL
{
    public class AccountBL: BaseBL, IAccountBL
    {
        #region Ctor
        public AccountBL(IStorage storage)
        {
            this.storage = storage;
            this.userRepository = storage.GetRepository<IUserRepository>();
        }
        #endregion
        #region Private 
        private IStorage storage;
        private IUserRepository userRepository;
        private async void SignIn(HttpContext context, UserDto user)
        {
            Claim[] claims = new[]
              {
                new Claim(ClaimTypes.Name, string.Format("user{0}{1}", user.Id,user.Name))
              };

            ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            ClaimsPrincipal principal = new ClaimsPrincipal(identity);

            await context.Authentication.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
        }

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

        public UserDto SignIn(HttpContext context,SignInViewModel viewModel)
        {
            var user = userRepository.GetByLoginAndSecret(viewModel.Login, viewModel.Password);
            if (user != null) SignIn(context, Convert(user));       
            return user != null ? 
                null 
                : Convert(user);
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
