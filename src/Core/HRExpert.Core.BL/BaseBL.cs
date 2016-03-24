using HRExpert.Core.Services.Abstractions;
namespace HRExpert.Core.BL
{
    public class BaseBL: Abstractions.IBaseBL
    {
        private IAuthService authService;
        public IAuthService AuthService { get { return authService; } }
        
        public BaseBL(IAuthService authService)
        {
            this.authService = authService;
        }
        
        public string GetCurrentUserName() => authService.CurrentContext.User.Identity.Name;
    }
}
