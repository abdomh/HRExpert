using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Organization.ViewModels
{
    public class PersonSelectViewModel
    {
        public string FieldName { get; set; }
        public List<IdNameViewModel> SelectOptions { get; set; }
    }
}
