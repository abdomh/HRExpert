using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    /// <summary>
    /// Вложенные файлы
    /// </summary>
    [Table("DocumentFiles")]
    public class DocumentFile : ExtCore.Data.Models.Abstractions.IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Key]
        public Guid Id { get; set; }
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
        /// Тип файла
        /// </summary>
        public int FileType { get; set; }
        /// <summary>
        /// Имя файла
        /// </summary>
        public string FileName { get; set; }
    }
}
