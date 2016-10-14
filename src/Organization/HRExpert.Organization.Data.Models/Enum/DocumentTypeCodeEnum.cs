using System.Collections.Generic;
namespace HRExpert.Organization.Data.Models
{
    public enum DocumentCodeEnum
    {
        /// <summary>
        /// Больничный лист
        /// </summary>
        Sicklist,
        /// <summary>
        /// Отпуск
        /// </summary>
        Vacation,
        /// <summary>
        /// Неявка
        /// </summary>
        Absence
    }
    public static class DocumentCodeConstants
    {
        /// <summary>
        /// Больничный лист
        /// </summary>
        public const string Sicklist = "Sicklist";
        /// <summary>
        /// Отпуск
        /// </summary>
        public const string Vacation = "Vacation";
        /// <summary>
        /// Неявка
        /// </summary>
        public const string Absence = "Absence";

        public static Dictionary<DocumentCodeEnum, string> Codes = new Dictionary<DocumentCodeEnum, string>
        {
            { DocumentCodeEnum.Absence, Absence },
            { DocumentCodeEnum.Sicklist, Sicklist },
            { DocumentCodeEnum.Vacation, Vacation }
        };
    }
    public static class DocumentCodeNames
    {
        /// <summary>
        /// Больничный лист
        /// </summary>
        public const string Sicklist = "Больничный лист";
        /// <summary>
        /// Отпуск
        /// </summary>
        public const string Vacation = "Отпуск";
        /// <summary>
        /// Неявка
        /// </summary>
        public const string Absence = "Неявка";

        public static Dictionary<string, string> Names = new Dictionary<string, string>
        {
            { DocumentCodeConstants.Absence, Absence },
            { DocumentCodeConstants.Sicklist, Sicklist },
            { DocumentCodeConstants.Vacation, Vacation }
        };
    }
    public static class DocumentColorConstants
    {
        /// <summary>
        /// Больничный лист
        /// </summary>
        public const string Sicklist = "#586492";
        /// <summary>
        /// Отпуск
        /// </summary>
        public const string Vacation = "#6ce37b";
        /// <summary>
        /// Неявка
        /// </summary>
        public const string Absence = "#f84252";

        public static Dictionary<DocumentCodeEnum, string> ByCodeEnum = new Dictionary<DocumentCodeEnum, string>
        {
            { DocumentCodeEnum.Absence, Absence },
            { DocumentCodeEnum.Sicklist, Sicklist },
            { DocumentCodeEnum.Vacation, Vacation }
        };
        public static Dictionary<string, string> ByCode = new Dictionary<string, string>
        {
            { DocumentCodeConstants.Absence, Absence },
            { DocumentCodeConstants.Sicklist, Sicklist },
            { DocumentCodeConstants.Vacation, Vacation }
        };
    }    
}
