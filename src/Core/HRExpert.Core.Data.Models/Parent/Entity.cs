using HRExpert.Core.Data.Models.Abstractions;
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
        public long Id { get; set; }
        
        /// <summary>
        /// Объект
        /// </summary>
        [ForeignKey("ObjectId")]
        public BaseObject Object { get; set; }

        public Entity()
        {
            this.Object = new BaseObject();
        }
    }
}
