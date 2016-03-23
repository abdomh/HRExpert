using HRExpert.Core.Data.Models.Abstractions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace HRExpert.Core.Data.Models.Parent
{
    /// <summary>
    /// Базовый класс сущности
    /// </summary>
    public class Entity: IEntity
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        [Column("Id")]
        [Key]
        public long Id { get; set; }
        
        
    }
}
