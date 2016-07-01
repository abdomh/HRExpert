using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Core.Data.Models
{
    public enum PermissionEnum: long
    {
        DoAll = 1,
        View = 2,
        Edit = 3,
        Delete = 4,
        TimesheetApproveEmployee = 5,
        TimesheetApproveManager = 6,
        TimesheetApprovePersonnelManager = 7,
        TimesheetEditPersonnelManager = 8
    }
}
