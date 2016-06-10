using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRExpert.Organization.Data.Models;
using HRExpert.Organization.DTO;
using HRExpert.Core.Services.Abstractions;
using HRExpert.Organization.Data.Abstractions;
using ExtCore.Data.Abstractions;
using HRExpert.Organization.BL.Converters;
namespace HRExpert.Organization.BL
{
    public class SicklistBL: Abstractions.ISicklistBL
    {
        private IAuthService authService;
        private ISicklistRepository sicklistRepository;
        private IDocumentTypesRepository documentTypeRepository;
        private ISicklistBabyMindingTypesRepository sicklistBabyMindingTypesRepository;
        private ISicklistTypesRepository sicklistTypesRepository;
        private ISicklistPaymentRestrictTypesRepository sicklistPaymentRestrictTypesRepository;
        private ISicklistPaymentPercentRepository sicklistPaymentPercentRepository;
        private ITimesheetStatusRepository timesheetStatusRepository;
        private IPersonRepository personRepository;
        public SicklistBL(IStorage storage, IAuthService authService)
        {
            this.sicklistRepository = storage.GetRepository<ISicklistRepository>();
            this.documentTypeRepository = storage.GetRepository<IDocumentTypesRepository>();
            this.personRepository = storage.GetRepository<IPersonRepository>();
            this.sicklistBabyMindingTypesRepository = storage.GetRepository<ISicklistBabyMindingTypesRepository>();
            this.sicklistPaymentPercentRepository = storage.GetRepository<ISicklistPaymentPercentRepository>();
            this.sicklistPaymentRestrictTypesRepository = storage.GetRepository<ISicklistPaymentRestrictTypesRepository>();
            this.sicklistTypesRepository = storage.GetRepository<ISicklistTypesRepository>();
            this.timesheetStatusRepository = storage.GetRepository<ITimesheetStatusRepository>();

            this.personRepository.CurrentRoleId = authService.CurrentRoleId;
            this.personRepository.CurrentUserId = authService.CurrentUser.Id;
            this.sicklistRepository.CurrentRoleId = authService.CurrentRoleId;
            this.sicklistRepository.CurrentUserId = authService.CurrentUser.Id;
            this.authService = authService;

            
        }
        public List<SicklistDto> List()
        {
            return sicklistRepository.List().Select(x => x.Convert()).ToList();
        }
        public SicklistDto Read(long Id)
        {
            return this.sicklistRepository.Read(Id).Convert();
        }
        public SicklistDto Create(SicklistDto dto)
        {
            var Person = personRepository.Read(dto.Person.Id);
            Sicklist entity = new Sicklist();
            entity.Document = new Document();
            entity.Document.Creator = personRepository.GetPersonByUserIdAndTargetDepartment(authService.CurrentUser.Id, Person.DepartmentId);
            entity.Document.Person = Person;
            entity.Document.DocumentType = documentTypeRepository.Read(1);
            entity.Document.CreateDate = DateTime.Now;
            entity.Document.Event = new PersonEvent();
            entity.Document.Event.BeginDate = dto.BeginDate;
            entity.Document.Event.EndDate = dto.EndDate;
            entity.Document.Event.Timesheet = new Timesheet();
            entity.Document.Event.Timesheet.IsStaffEstablishedPostTemporaryFree = false;
            if(dto.TimesheetStatus!=null)
                entity.Document.Event.Timesheet.Status = timesheetStatusRepository.Read(dto.TimesheetStatus.Id);
            if (dto.SicklistBabyMindingType != null)
                entity.SicklistBabyMindingType = sicklistBabyMindingTypesRepository.Read(dto.SicklistBabyMindingType.Id);
            if(dto.SicklistPaymentPercent!=null)
                entity.SicklistPaymentPercent = sicklistPaymentPercentRepository.Read(dto.SicklistPaymentPercent.Id);
            if(dto.SicklistPaymentRestrictType!=null)
                entity.SicklistPaymentRestrictType = sicklistPaymentRestrictTypesRepository.Read(dto.SicklistPaymentRestrictType.Id);
            if(dto.SicklistType!=null)
                entity.SicklistType = sicklistTypesRepository.Read(dto.SicklistType.Id);
            entity.SicklistNumber = dto.SicklistNumber;
            this.sicklistRepository.Create(entity);
            return entity.Convert();
        }

    }
}
