using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Organization.ViewModels
{
    public class ReferencySelectViewModel
    {
        public string FieldName { get; set; }
        public int CurrentValue { get; set; }
        public bool IsEditable { get; set; }
        public List<IdNameViewModel> SelectOptions { get; set; }
    }
}
