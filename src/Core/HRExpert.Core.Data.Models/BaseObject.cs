using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRExpert.Core.Data.Models.Abstractions;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models
{
    /// <summary>
    /// Объект
    /// </summary>
    [Table("BaseObjects")]
    public class BaseObject
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Column("Id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        /// <summary>
        /// Идентификатор 1C
        /// </summary>
        [Column("Id_1C")]
        public Guid Id_1C { get; set; }
        /// <summary>
        /// Класс
        /// </summary>
        [ForeignKey("ClassId")]
        public BaseClass Class { get; set; }
        /// <summary>
        /// Название
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }
        /// <summary>
        /// Описание
        /// </summary>
        [Column("Description")]
        public string Description { get; set; }
        /// <summary>
        /// Номер версии
        /// </summary>
        [Column("Version")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Version { get; set; }
        /// <summary>
        /// Дата создания
        /// </summary>
        [Column("CreateDate")]
        public DateTime? CreateDate { get; set; }
        /// <summary>
        /// Дата удаления
        /// </summary>
        [Column("DeleteDate")]
        public DateTime? DeleteDate { get; set; }
    }
}
