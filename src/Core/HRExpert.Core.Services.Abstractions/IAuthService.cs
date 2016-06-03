using Microsoft.AspNetCore.Http;
using HRExpert.Core.Data.Models;
namespace HRExpert.Core.Services.Abstractions
{
    /// <summary>
    /// Сервис доступа к данным текущего контекста
    /// </summary>
    public interface IAuthService
    {
        /// <summary>
        /// Текущий контекст
        /// </summary>
        HttpContext CurrentContext { get;}
        /// <summary>
        /// Идентификатор текущей роли
        /// </summary>
        long CurrentRoleId { get; set; }
        /// <summary>
        /// Текущий пользователь
        /// </summary>  
        User CurrentUser { get; }
        /// <summary>
        /// Проверка прав пользователя
        /// </summary>
        /// <param name="PermissionId">Идентификтор прав</param>
        /// <returns>true, если есть права, false в противном случае</returns>
        bool CheckPermission(long PermissionId);
    }
}
