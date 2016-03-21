using HRExpert.Core.Data.Models.Abstractions;
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
        public long Id { get; set; }
    }
}
