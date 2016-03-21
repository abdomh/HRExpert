using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRExpert.Core.Data.Models.Abstractions;
namespace HRExpert.Core.Data.Models
{
    /// <summary>
    /// Объект
    /// </summary>
    public class BaseObject
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// Идентификатор 1C
        /// </summary>
        public Guid Id_1C { get; set; }
        /// <summary>
        /// Класс
        /// </summary>
        public BaseClass Class { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Номер версии
        /// </summary>
        public int Version { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// Дата удаления
        /// </summary>
        public DateTime? DeleteDate { get; set; }  
        /// <summary>
        /// Создатель
        /// </summary>
        public User Creator { get; set; }
    }
}
