namespace HRExpert.Core
{
    public static class CoreConstants
    {
        /// <summary>
        /// API
        /// </summary>
        public const string Api = "/api";
        /// <summary>
        /// Профиль
        /// </summary>
        public const string ProfileController = Api + "/Profile";

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
        /// <summary>
        /// Путь к пользователям
        /// </summary>
        public const string UsersController = Api + UsersList;
        /// <summary>
        /// Путь к пользователю по ключу
        /// </summary>
        public const string UsersController_key = UsersController + UserKey;
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
        /// Путь к списку ролей
        /// </summary>
        public const string RolesController = Api + RolesList;
        /// <summary>
        /// Путь к роли по ключу
        /// </summary>
        public const string RolesController_key = RolesController + RoleKey;
        /// <summary>
        /// Путь к ролям пользователя
        /// </summary>
        public const string RolesControllerPath = UsersController_key + RolesList;
        /// <summary>
        /// Путь к роли пользователя по ключу
        /// </summary>
        public const string RolesControllerPath_key = RolesControllerPath + RoleKey;
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
        /// <summary>
        /// Путь к списку модулей
        /// </summary>
        public const string SectionsController = Api + SectionsList;
        /// <summary>
        /// Путь к модулю по ключу
        /// </summary>
        public const string SectionsController_key = SectionsController + SectionKey;
        /// <summary>
        /// Путь к модулям роли
        /// </summary>
        public const string SectionsControllerPath = RolesControllerPath_key + SectionsList;
        /// <summary>
        /// Путь к модулю роли по ключу
        /// </summary>
        public const string SectionsControllerPath_key = SectionsControllerPath + SectionKey;
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
        /// <summary>
        /// Путь к правам
        /// </summary>
        public const string PermissionsController = Api + PermissionsList;
        /// <summary>
        /// Путь к правам по ключу
        /// </summary>
        public const string PermissionsController_key = PermissionsList + PermissionKey;
        /// <summary>
        /// Путь к правам модуля
        /// </summary>
        public const string PermissionsControllerPath = SectionsControllerPath_key + PermissionsList;
        /// <summary>
        /// Путь к правам модуля по ключу
        /// </summary>
        public const string PermissionsControllerPath_key = PermissionsControllerPath + PermissionKey;


    }
}
