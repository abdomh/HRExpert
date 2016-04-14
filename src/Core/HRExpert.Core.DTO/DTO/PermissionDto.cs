using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Core.DTO
{
    public class PermissionDto : IdNameDto
    {
        public SectionDto Section { get; set; }
    }
}
