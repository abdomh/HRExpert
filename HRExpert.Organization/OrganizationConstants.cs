using HRExpert.Core;
namespace HRExpert.Organization
{
    /// <summary>
    /// Константы для API организации
    /// </summary>
    public static class OrganizationConstants 
    {
        /// <summary>
        /// Организация
        /// </summary>
        public const string Organization = "organization";
        /// <summary>
        /// Список организаций
        /// </summary>
        public const string OrganizationList = "/" + Organization + "s";
        /// <summary>
        /// Организация по ключу
        /// </summary>
        public const string OrganizationKey = "({" + Organization + "id})";
        /*
        /// <summary>
        /// Путь к контроллеру организаций
        /// </summary>
        public const string OrganizationController = CoreConstants.Api + OrganizationList;
        /// <summary>
        /// Путь к организации по ключу
        /// </summary>
        public const string OrganizationController_key = OrganizationController + OrganizationKey;
        */
        //Подразделения
        /// <summary>
        /// Подразделение
        /// </summary>
        public const string Department = "department";
        /// <summary>
        /// Список подразделений
        /// </summary>
        public const string DepartmentList = "/" + Department + "s";
        /// <summary>
        /// Подразделение по ключу
        /// </summary>
        public const string DepartmentKey = "({" + Department + "id})";
        /*
        /// <summary>
        /// Путь к подразделениям
        /// </summary>
        public const string DepartmentController = CoreConstants.Api + DepartmentList;
        /// <summary>
        /// Путь к подразделению по ключу
        /// </summary>
        public const string DepartmentController_key = DepartmentController + DepartmentKey;
        public const string DepartmentController_key_childs = DepartmentController_key + "/childs";
        /// <summary>
        /// Путь к подразделениям организации
        /// </summary>
        public const string DepartmentControllerPath = OrganizationController_key + DepartmentList;
        /// <summary>
        /// Путь к подразделению организации по ключу
        /// </summary>
        public const string DepartmentControllerPath_key = DepartmentControllerPath + DepartmentKey;
        public const string DepartmentControllerPath_key_childs = DepartmentControllerPath_key + "/childs";
        */

        //Штатные единицы 
        /// <summary>
        /// Штатные единицы
        /// </summary>
        public const string StaffEstablishedPosts = "staffestablishedpost";
        /// <summary>
        /// Список штатных единиц
        /// </summary>
        public const string StaffEstablishedPostsList = "/" + StaffEstablishedPosts + "s";
        
        /*
        /// <summary>
        /// Путь к штатным единицам
        /// </summary>
        public const string StaffEstablishedPostsController = CoreConstants.Api + StaffEstablishedPostsList;
        /// <summary>
        /// Путь к штатным единицам по ключу должности
        /// </summary>
        public const string StaffEstablishedPostsController_key = StaffEstablishedPostsController + PositionsKey;
        /// <summary>
        /// Путь к штатным единицам подразделения
        /// </summary>
        public const string StaffEstablishedPostsControllerPath =  DepartmentControllerPath_key + StaffEstablishedPostsList;
        /// <summary>
        /// Путь к штатной единице подразделения по ключу должности
        /// </summary>
        public const string StaffEstablishedPostsControllerPath_key = StaffEstablishedPostsControllerPath + PositionsKey;
        */

        //Персонажи
        /// <summary>
        /// Персонаж
        /// </summary>
        public const string Person = "person";
        /// <summary>
        /// Список персонажей
         /// </summary>
        public const string PersonList = "/" + Person + "s";
        /// <summary>
        /// Персонаж по ключу
        /// </summary>
        public const string PersonKey = "({" + Person + "id})";
        /*
        /// <summary>
        /// Путь к персонажам
        /// </summary>
        public const string PersonsController = CoreConstants.Api + PersonList;
        /// <summary>
        /// Путь к персонажу по ключу
        /// </summary>
        public const string PersonsController_key = PersonsController + PersonKey;
        /// <summary>
        /// Путь к персонажам штатной единицы
        /// </summary>
        public const string PersonsControllerPath = StaffEstablishedPostsControllerPath_key + PersonList;
        /// <summary>
        /// Путь к персонажу штатной единицы по ключу
        /// </summary>
        public const string PersonsControllerPath_key = PersonsControllerPath + PersonKey;
        */

        //Должности
        /// <summary>
        /// Должности
        /// </summary>
        public const string Positions = "position";
        /// <summary>
        /// Список должностей
        /// </summary>
        public const string PositionsList = "/" + Positions + "s";
        /// <summary>
        /// Должность по ключу
        /// </summary>
        public const string PositionsKey = "({" + Positions + "id})";
        /*
        /// <summary>
        /// Путь к должностям 
        /// </summary>
        public const string PositionsController = CoreConstants.Api + PositionsList;
        /// <summary>
        /// Путь к должности по ключу
        /// </summary>
        public const string PositionsController_key = PositionsController + PositionsKey;
        */
        public const string TimesheetStatus = "timesheetstatus";
        public const string TimesheetStatusList = "/" + TimesheetStatus + "es";
        public const string Timesheet = "timesheet";
        public const string TimesheetList = "/" + Timesheet + "s";
        public const string Sicklist = "sicklist";
        public const string SicklistList = "/" + Sicklist + "s";
        public const string SicklistKey = "({" + Sicklist + "id})";
        public const string SicklistType = "sicklisttype";
        public const string SicklistTypeList = "/" + SicklistType + "s";
        public const string SicklistBabyMindingType = "sicklistbabymindingtype";
        public const string SicklistBabyMindingTypeList = "/" + SicklistBabyMindingType + "s";
        public const string SicklistPaymentRestrictType = "sicklistpaymentrestricttype";
        public const string SicklistPaymentRestrictTypeList = "/" + SicklistPaymentRestrictType + "s";
        public const string SicklistPaymentPercent = "sicklistpaymentpercent";
        public const string SicklistPaymentPercentList = "/" + SicklistPaymentPercent + "s";
    }
}
