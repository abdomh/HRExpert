using HRExpert.Core.Data.Models;
namespace HRExpert.Core.Data.Abstractions
{
    public interface ICredentialRepository: ExtCore.Data.Abstractions.IRepository
    {
        Credential GetByValueTypeCodeAndSecret(string Value, string TypeCode, string Secret);
    }
}
