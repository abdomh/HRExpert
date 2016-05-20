using System.Security.Claims;
using System.Linq;
using Microsoft.AspNet.Http;
using Microsoft.Extensions.DependencyInjection;
using ExtCore.Data.Abstractions;
using HRExpert.Core.Data.Models;
using HRExpert.Core.Data.Abstractions;
using System;

namespace HRExpert.Core.Services
{
    /// <summary>
    /// Сервис аутентификации
    /// </summary>
    public class AuthService: Abstractions.IAuthService
    {
        private IStorage storage;
        private IUserRepository userRepository;
        private User currentUser;
        private IHttpContextAccessor contextaccessor;
        public AuthService(IStorage storage, IHttpContextAccessor contextaccessor)
        {
            this.storage = storage;
            this.contextaccessor = contextaccessor;            
            userRepository = storage.GetRepository<IUserRepository>();
        }
        /// <summary>
        /// Текущий контекст
        /// </summary>
        public HttpContext CurrentContext
        {
            get { return this.contextaccessor.HttpContext; }
        }
        public long CurrentRoleId { get; set; }
        /// <summary>
        /// Текущий пользователь
        /// </summary>
        public User CurrentUser
        {
            get
            {
                if (currentUser == null)
                {
                    long id = long.Parse(CurrentContext.User.Claims.Where(x => x.Type == ClaimTypes.UserData)?.First()?.Value);
                    currentUser = userRepository.Profile(id);
                }
                return currentUser;
            }
        }        
        /// <summary>
        /// Проверка прав пользователя
        /// </summary>
        /// <param name="PermissionId">Идентификтор прав</param>
        /// <returns>true, если есть права, false в противном случае</returns>
        public bool CheckPermission(long PermissionId)
        {
            foreach(var role in CurrentUser.Roles)
            {
                if(role.Role.Permissions.Any(x => x.PermissionTypeId == PermissionId)) return true;
            }
            return false;
        }      
    }
}
