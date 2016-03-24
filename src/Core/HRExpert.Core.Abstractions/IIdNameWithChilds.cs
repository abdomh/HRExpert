using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Core.Abstractions
{
    public interface IIdNameWithChilds: IIdName
    {
        IList<IIdNameWithChilds> Childs { get; set; }
    }
}
