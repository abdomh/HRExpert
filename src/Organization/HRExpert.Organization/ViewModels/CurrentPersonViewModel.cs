using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Organization.ViewModels
{
    public class CurrentPersonViewModel
    {
        public CurrentPersonViewModel()
        {
            this.Links = new List<LinkViewModel>();
        }
        public string Name { get; set; }
        public List<LinkViewModel> Links { get; set; }
    }
}
