using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.Abstractions
{
    public interface IPersonEventsRepository : ExtCore.Data.Abstractions.IRepository
    {
        List<PersonEvent> GetPersonEvents(Expression<Func<PersonEvent, bool>> searchOptions);
        void Create(PersonEvent entity);
        void Delete(PersonEvent entity);
        void Delete(Guid Id);
        List<PersonEvent> List();
        PersonEvent Read(Guid DocumentGuid);
        void Update(PersonEvent entity);
    }
}