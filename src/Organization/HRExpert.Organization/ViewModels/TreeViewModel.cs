using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Organization.ViewModels
{
    public class TreeViewModel
    {
        public string SelectedId {get;set;}
        public string SelectedName { get; set; }
        public IEnumerable<TreeElementViewModel> data { get; set; }
    }
}
