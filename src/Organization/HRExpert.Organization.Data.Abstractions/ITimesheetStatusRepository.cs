using System.Collections.Generic;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.Abstractions
{
    public interface ITimesheetStatusRepository : ExtCore.Data.Abstractions.IRepository
    {
        void Create(TimesheetStatus entity);
        void Delete(TimesheetStatus entity);
        void Delete(int Id);
        List<TimesheetStatus> List();
        TimesheetStatus Read(int Id);
        void Update(TimesheetStatus entity);
    }
}