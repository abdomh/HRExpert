namespace HRExpert.Core
{
    /// <summary>
    /// Константы для API
    /// </summary>
    public static class CoreConstants
    {
        /// <summary>
        /// API
        /// </summary>
        public const string Api = "/api";
        /// <summary>
        /// Версия
        /// </summary>
        public const string version = "/v1";
        /// <summary>
        /// Дочерние элементы
        /// </summary>
        public const string Childs = "/childs";
        /// <summary>
        /// Профиль
        /// </summary>
        public const string ProfileController = Api + version + "/Profile";

        //Пользователи
        /// <summary>
        /// Пользователи
        /// </summary>
        public const string Users = "user";
        /// <summary>
        /// Список пользователей
        /// </summary>
        public const string UsersList = "/" + Users + "s";
        /// <summary>
        /// Пользователь по ключу
        /// </summary>
        public const string UserKey = "({" + Users + "id})";
        
        //Роли
        /// <summary>
        /// Роли
        /// </summary>
        public const string Roles = "role";
        /// <summary>
        /// Список ролей
        /// </summary>
        public const string RolesList = "/" + Roles + "s";
        /// <summary>
        /// Роль по ключу
        /// </summary>
        public const string RoleKey = "({" + Roles + "id})";        
        
        /// <summary>
        /// Модули
        /// </summary>
        public const string Sections = "section";
        /// <summary>
        /// Список модулей
        /// </summary>
        public const string SectionsList = "/" + Sections + "s";
        /// <summary>
        /// Модуль по ключу
        /// </summary>
        public const string SectionKey = "({" + Sections + "id})";
        
        //Права
        /// <summary>
        /// Права
        /// </summary>
        public const string Permissions = "permission";
        /// <summary>
        /// Список прав
        /// </summary>
        public const string PermissionsList = "/" + Permissions + "s";
        /// <summary>
        /// Права по ключу
        /// </summary>
        public const string PermissionKey = "({" + Permissions + "id})";
        
    }
}
