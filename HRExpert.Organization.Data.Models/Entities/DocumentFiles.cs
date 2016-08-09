using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Organization.Data.Models
{
    using Core.Data.Models.Abstractions;
    /// <summary>
    /// Вложенные файлы
    /// </summary>
    [Table("DocumentFiles")]
    public class DocumentFile : IEntity<Guid>
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
        /// <summary>
        /// Путь к файлу
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Коллекция подписанных фалов
        /// </summary>
        public ICollection<SignedFile> Signs { get; set; }
    }
}
