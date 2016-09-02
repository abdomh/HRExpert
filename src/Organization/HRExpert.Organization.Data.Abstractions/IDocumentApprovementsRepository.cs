using System;
using System.Collections.Generic;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.Abstractions
{
    public interface IDocumentApprovementsRepository : ExtCore.Data.Abstractions.IRepository
    {
        void Create(DocumentApprovement entity);
        void Delete(DocumentApprovement entity);
        void Delete(Guid DocumentGuid, int ApprovePosition);
        List<DocumentApprovement> List();
        List<DocumentApprovement> List(Guid DocumentGuid);
        DocumentApprovement Read(Guid DocumentGuid, int ApprovePosition);
        void Update(DocumentApprovement entity);
    }
}