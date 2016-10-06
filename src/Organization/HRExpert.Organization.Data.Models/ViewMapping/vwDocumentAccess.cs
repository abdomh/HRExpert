using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Organization.Data.Models
{
    public class vwDocumentAccess
    {
        public Guid DocumentGuid { get; set; }
        public int AccessUserId { get; set; }
        public int AccessPersonId { get; set; }
        public int AccessRoleId { get; set; }
    }
}
