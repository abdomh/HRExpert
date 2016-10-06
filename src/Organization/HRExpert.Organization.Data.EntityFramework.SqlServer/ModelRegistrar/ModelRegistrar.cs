using Microsoft.EntityFrameworkCore;
using ExtCore.Data.EntityFramework.SqlServer;
using HRExpert.Organization.Data.Models;

namespace HRExpert.Organization.Data.EntityFramework.SqlServer
{
    public class ModelRegistrar : IModelRegistrar
    {
        public void RegisterModels(ModelBuilder modelbuilder)
        {
            //Организация
            modelbuilder.Entity<Models.Organization>();
            modelbuilder.Entity<Department>().HasMany(x=>x.Childs).WithOne(x=>x.Parent).HasForeignKey(x=>x.ParentId);            
            modelbuilder.Entity<Position>();
            modelbuilder.Entity<StaffEstablishedPost>().HasKey(x => new { x.DepartmentId, x.PositionId });
            modelbuilder.Entity<Person>().HasOne(x => x.StaffEstablishedPost);
            //Привязки доступа
            modelbuilder.Entity<AccessLink>().HasKey(x => new { x.DepartmentId, x.PersonId, x.RoleId });
            modelbuilder.Entity<AccessLink>().HasOne(x => x.Department).WithMany(x => x.AccessLinks).HasForeignKey(x => x.DepartmentId);
            modelbuilder.Entity<AccessLink>().HasOne(x => x.Person).WithMany(x => x.AccessLinks).HasForeignKey(x => x.PersonId);
            //Документы
            modelbuilder.Entity<Document>();
            modelbuilder.Entity<DocumentStatus>();
            modelbuilder.Entity<DocumentType>();
            modelbuilder.Entity<DocumentFile>();
            modelbuilder.Entity<DocumentApprovement>().HasKey(x=> new { x.DocumentGuid, x.ApprovePosition });
            //События
            modelbuilder.Entity<PersonEvent>();
            //Табель
            modelbuilder.Entity<Timesheet>();
            modelbuilder.Entity<TimesheetStatus>();
            //Больничные
            modelbuilder.Entity<Sicklist>();
            modelbuilder.Entity<SicklistType>();
            modelbuilder.Entity<SicklistBabyMindingType>();
            modelbuilder.Entity<SicklistPaymentPercent>();
            modelbuilder.Entity<SicklistPaymentRestrictType>();
            ///
            modelbuilder.Entity<SignedFile>();
            //modelbuilder.Entity<vwDocumentAccess>();
                  
        }
    }
}
