using System;
using System.Collections.Generic;
namespace HRExpert.Organization.DTO
{
    /// <summary>
    /// Документ
    /// </summary>
    public class DocumentDto<T>
    {
        /// <summary>
        /// Создатель
        /// </summary>
        public PersonDto Creator { get; set; }
        /// <summary>
        /// Сотрудник к которому относится документ
        /// </summary>
        public PersonDto Person { get; set; }
        /// <summary>
        /// Дата создания документа
        /// </summary>
        public DateTime CreateDate { get; set; }        
        /// <summary>
        /// Тип документа
        /// </summary>
        public DocumentTypeDto DocumentType { get; set; }
        /// <summary>
        /// Данные документа
        /// </summary>
        public T Data { get; set; }
        /// <summary>
        /// Файлы
        /// </summary>
        public FileDto[] Files { get; set; }
        /// <summary>
        /// Согласования
        /// </summary>
        public DocumentApprovementDto[] Approvements { get; set; }
        
    }
}
