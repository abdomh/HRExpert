using System.Collections.Generic;
namespace HRExpert.Core.Data.Abstractions
{
    public interface IReferencyRepository<T>: ExtCore.Data.Abstractions.IRepository 
    {
        IEnumerable<T> All();
        void Create(T entity);
        T Read(long Id);
        void Update(T entity);
        void Delete(T entity);
        void Delete(long Id);
        T GetByCode(string code);
    }
}
