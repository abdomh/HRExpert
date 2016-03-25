namespace HRExpert.Core.Data.Abstractions
{
    public interface IReferencyRepository<T>: ExtCore.Data.Abstractions.IRepository 
    {
        T GetByCode(string code);
    }
}
