using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Core.DTO.ViewModels
{
    public class RelationEditViewModel
    {
        public RelationDto Relation { get; set; }
        public IList<IdNameDto> RightList { get; set; }
    }
}
