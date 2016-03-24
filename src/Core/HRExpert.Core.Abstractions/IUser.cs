using System.Collections.Generic;
namespace HRExpert.Core.Abstractions
{
    public interface IUser:IIdName
    {        
        Enum.RolesEnum Role { get; }                       
    }
}
