using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Organization.ViewModels
{
    public class TreeElementViewModel
    {
        public string text { get; set; }
        public int id { get; set; }
        public int? parentId { get; set; }
        public IEnumerable<TreeElementViewModel> children { get; set; }
    }
}
