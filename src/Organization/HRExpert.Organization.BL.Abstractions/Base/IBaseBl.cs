using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Platformus.Barebone;
namespace HRExpert.Organization.BL.Abstractions
{
    public interface IBaseBl
    {
        void SetHandler(IHandler handler);
    }
}
