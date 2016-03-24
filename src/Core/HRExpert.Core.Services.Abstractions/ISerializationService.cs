using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Core.Services.Abstractions
{
    public interface ISerializationService
    {
        string Serialize<T>(T obj);
        T Deserialize<T>(string obj);
    }
}
