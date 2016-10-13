using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Http;
using Platformus.Security;
namespace HRExpert.Organization.BL
{
    public class MainService : Abstractions.IMainService, Platformus.Barebone.IHandler
    {
        private IHttpContextAccessor httpContextAccessor;
        private IStorage storage;
        public MainService(IStorage storage, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.storage = storage;

        }
        public bool IsUserLoggedIn { get { return this.HttpContext.User.Identity.IsAuthenticated; } }
        private UserManager userManager;
        public UserManager UserManager
        {
            get { if (userManager == null) userManager = new UserManager(this); return userManager; }            
        }
        public int CurrentUserId
        {
            get { return this.UserManager.GetCurrentUser().Id; }
        }

        public HttpContext HttpContext
        {
            get
            {
                return this.httpContextAccessor.HttpContext;
            }
        }

        public IStorage Storage
        {
            get
            {
                return this.storage;
            }
        }
    }
}
