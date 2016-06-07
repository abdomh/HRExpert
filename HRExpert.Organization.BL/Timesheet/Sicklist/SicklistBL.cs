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
        private IPersonRepository personRepository;
        public SicklistBL(IStorage storage, IAuthService authService)
        {
            this.sicklistRepository = storage.GetRepository<ISicklistRepository>();
            this.documentTypeRepository = storage.GetRepository<IDocumentTypesRepository>();
            this.personRepository = storage.GetRepository<IPersonRepository>();
            this.authService = authService;
        }
        public List<DocumentDto<SicklistDto>> List()
        {
            return sicklistRepository.List().Select(x => x.Convert()).ToList();
        }
        public DocumentDto<SicklistDto> Read(long Id)
        {
            return this.sicklistRepository.Read(Id).Convert();
        }
        public DocumentDto<SicklistDto> Create(DocumentDto<SicklistDto> dto)
        {
            var Person = personRepository.Read(dto.Person.Id);
            Sicklist entity = new Sicklist();
            entity.Document = new Document();
            entity.Document.Creator = personRepository.GetPersonByUserIdAndTargetDepartment(authService.CurrentUser.Id, Person.DepartmentId);
            entity.Document.PersonId = dto.Person.Id;
            entity.Document.DocumentType = documentTypeRepository.Read(1);
            entity.Document.CreateDate = DateTime.Now;
            entity.Document.Event = new PersonEvent();
            entity.Document.Event.BeginDate = dto.Data.BeginDate;
            entity.Document.Event.EndDate = dto.Data.EndDate;
            entity.Document.Event.Timesheet = new Timesheet();
            entity.Document.Event.Timesheet.IsStaffEstablishedPostTemporaryFree = false;
            entity.Document.Event.Timesheet.StatusId = dto.Data.TimesheetStatus.Id;
            entity.SicklistBabyMindingTypeId = dto.Data.SicklistBabyMindingType.Id;
            entity.SicklistNumber = dto.Data.SicklistNumber;
            entity.SicklistPaymentPercentId = dto.Data.SicklistPaymentPercent.Id;
            entity.SicklistPaymentRestrictTypeId = dto.Data.SicklistPaymentRestrictType.Id;
            entity.SicklistTypeId = dto.Data.Type.Id;
            return entity.Convert();
        }

    }
}
