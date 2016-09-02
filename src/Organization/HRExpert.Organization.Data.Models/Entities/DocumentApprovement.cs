using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    /// <summary>
    /// Согласования документов
    /// </summary>
    [Table("DocumentApprovements")]
    public class DocumentApprovement: Abstractions.IEntity
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
        public int? PersonId { get; set; }
        /// <summary>
        /// Идентификатор реального согласованта
        /// </summary>
        [ForeignKey("RealPerson")]
        public int? RealPersonId { get; set; }
        /// <summary>
        /// Согласовант
        /// </summary>
        public Person Person { get; set; }
        /// <summary>
        /// Реальный согласовант
        /// </summary>
        public Person RealPerson { get; set; }
        /// <summary>
        /// Позиция согласования
        /// </summary>
        public int ApprovePosition { get; set; }
        /// <summary>
        /// Дата согласования
        /// </summary>
        public DateTime? DateAccept { get; set; }
        /// <summary>
        /// Согласование
        /// </summary>
        public bool isAccept { get; set; }
    }
}
