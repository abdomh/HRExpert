using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRExpert.Core.DTO;
namespace HRExpert.Core.BL.Abstractions
{
    public interface IBaseBL
    {
        string GetCurrentUserName();
    }
}
