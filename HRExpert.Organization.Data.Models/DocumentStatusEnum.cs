using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRExpert.Organization.Data.Models
{
    public enum DocumentStatusEnum
    {
        Draft = 1,
        SendedTo1C =2,
        ApprovedByEmployee =3,
        ApprovedByManager = 4,
        ApprovedByPersonnelManager= 5
    }
}
