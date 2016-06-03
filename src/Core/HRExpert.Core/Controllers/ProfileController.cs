using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using HRExpert.Core.BL.Abstractions;
using HRExpert.Core.DTO;

namespace HRExpert.Core.Controllers.api
{
    /// <summary>
    /// Контроллер профиля(доступ только авторизованным пользователям)
    /// </summary>
    [Authorize]
    public class ProfileController: Controller
    {
        /// <summary>
        /// Бизнес логика пользователей
        /// </summary>
        private IUsersBL userBl;
        #region Ctor
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="userBl"></param>
        public ProfileController(IUsersBL userBl)
        {
            this.userBl = userBl;
        }
        #endregion
        /// <summary>
        /// Получение профиля
        /// </summary>
        /// <returns>Профиль</returns>
        [Route(CoreConstants.ProfileController)]
        [HttpGet]
        public ProfileDto Profile()
        {
            return userBl.Profile();
        }
    }
}
