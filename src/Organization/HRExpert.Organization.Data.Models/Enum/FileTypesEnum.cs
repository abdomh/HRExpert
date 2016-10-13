using System.Collections.Generic;

namespace HRExpert.Organization.Data.Models
{
    public enum FileTypesEnum
    {
        SicklistDocument = 1
    }
    public static class FileTypesNames
    {
        public const string SicklistDocument = "Больничный лист";
        public static Dictionary<FileTypesEnum, string> Names = new Dictionary<FileTypesEnum, string> {
            {FileTypesEnum.SicklistDocument, SicklistDocument }
        };
    }
}
