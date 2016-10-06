using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Linq;
using HRExpert.Organization.DTO;
namespace HRExpert.Organization.ViewTools
{
    public class PermissionCheck
    {
        private HashSet<string> _permissions = new HashSet<string>();
        public HttpContext Context { get; set; }
        public bool IsUserLoggedIn
        {
            get { return Context.User.Identity.IsAuthenticated; }
        }
        public void SetPermissions(IEnumerable<string> permissions)
        {
            _permissions = new HashSet<string>();                        
            foreach(var el in permissions)
            {
                _permissions.Add(el);
            }
        }

        public bool HasPermission(string permission)
        {
            return _permissions.Contains(permission);
        }
    }
}
