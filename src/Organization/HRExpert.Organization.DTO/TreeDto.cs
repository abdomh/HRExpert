using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Organization.DTO
{
    public class TreeDto
    {
        public TreeDto()
        {
            this.children = new List<TreeDto>();
        }
        public int id { get; set; }
        public int? parentId { get; set; }
        public string text { get; set; }
        public List<TreeDto>  children { get; set; }
    }
}
