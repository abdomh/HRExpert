using ExtCore.Data.Abstractions;
using Microsoft.AspNetCore.Http;

namespace HRExpert.Organization.BL
{
    public class MainService : Abstractions.IMainService
    {
        private IHttpContextAccessor httpContextAccessor;
        private IStorage storage;
        public MainService(IStorage storage, IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.storage = storage;

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
