using System.Collections.Generic;
namespace HRExpert.Organization.Data.Models
{
    public enum DocumentStatusEnum
    {
        /// <summary>
        /// Черновик
        /// </summary>
        Draft = 1,
        /// <summary>
        /// Согласован
        /// </summary>
        Approved = 2,
        /// <summary>
        /// Выгружен в 1С
        /// </summary>
        SendedTo1C =3,
        /// <summary>
        /// Отменен
        /// </summary>
        Cancelled = 4,
        /// <summary>
        /// В процессе согласования
        /// </summary>
        WorkInProgress = 5        
    }
    public static class DocumentStatusCodeConstants
    {
        public const string Draft = "Draft";
        public const string Approved = "Approved";
        public const string Sended = "Sended";
        public const string Canceled = "Canceled";
        public const string WorkInProgress = "WorkInProgress";

        public static Dictionary<DocumentStatusEnum, string> Codes = new Dictionary<DocumentStatusEnum, string>{
             { DocumentStatusEnum.Draft, Draft },
             { DocumentStatusEnum.SendedTo1C, Sended },
             { DocumentStatusEnum.WorkInProgress, WorkInProgress },
             { DocumentStatusEnum.Cancelled, Canceled },
             { DocumentStatusEnum.Approved, Approved }
        };
    }   
}
