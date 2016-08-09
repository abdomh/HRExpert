using System;
using System.Collections.Generic;
namespace HRExpert.Core.Data.Models.Abstractions
{
    /// <summary>
    /// Интерфейс сущности
    /// </summary>
    public interface IEntity: ExtCore.Data.Models.Abstractions.IEntity
    {
    }
    /// <summary>
    /// Интерфейс сущности с идентификатором
    /// </summary>
    /// <typeparam name="T">Тип идентификатора</typeparam>
    public interface IEntity<T>:IEntity where T : struct
    {
        T Id { get; set; }
    }
    /// <summary>
    /// Equality comparer by Id
    /// </summary>
    /// <typeparam name="T">Id type</typeparam>
    public class IdEqualityComparer<T> : IEqualityComparer<IEntity<T>> where T : struct
    {
        public bool Equals(IEntity<T> x, IEntity<T> y)
        {
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(IEntity<T> obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
