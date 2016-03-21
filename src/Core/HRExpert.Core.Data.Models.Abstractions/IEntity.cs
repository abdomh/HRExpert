namespace HRExpert.Core.Data.Models.Abstractions
{
    /// <summary>
    /// Интерфейс сущности
    /// </summary>
    public interface IEntity: ExtCore.Data.Models.Abstractions.IEntity
    {
        long Id { get; set; }
    }
}
