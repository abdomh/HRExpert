namespace HRExpert.Organization.Data.Models.Abstractions
{
    public interface IEntity: ExtCore.Data.Models.Abstractions.IEntity
    {
    }
    public interface IEntity<T> : IEntity
    {
        T Id { get; set; }
    }
}
