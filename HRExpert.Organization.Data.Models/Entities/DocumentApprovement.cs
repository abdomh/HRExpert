using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    /// <summary>
    /// Согласования документов
    /// </summary>
    [Table("DocumentApprovements")]
    public class DocumentApprovement: ExtCore.Data.Models.Abstractions.IEntity
    {
        /// <summary>
        /// Идентификатор документа
        /// </summary>
        [ForeignKey("Document")]
        public Guid DocumentGuid { get; set; }
        /// <summary>
        /// Документ
        /// </summary>
        public Document Document { get; set; }
        /// <summary>
        /// Идентификатор согласованта
        /// </summary>
        [ForeignKey("Person")]
        public long PersonId { get; set; }
        /// <summary>
        /// Согласовант
        /// </summary>
        public Person Person { get; set; }
        /// <summary>
        /// Позиция согласования
        /// </summary>
        public int ApprovePosition { get; set; }
        /// <summary>
        /// Дата согласования
        /// </summary>
        public DateTime? DateAccept { get; set; }
    }
}
