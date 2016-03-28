using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Core.DTO
{
    public class RelationDto
    {
        public IdNameDto Left { get; set; }
        public IdNameDto Right { get; set; }
    }
}
