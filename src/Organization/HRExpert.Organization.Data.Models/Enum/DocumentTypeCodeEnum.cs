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
}
