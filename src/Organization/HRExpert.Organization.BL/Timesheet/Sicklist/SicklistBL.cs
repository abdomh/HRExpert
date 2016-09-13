using System;
using System.Collections.Generic;
using System.Linq;
using HRExpert.Organization.Data.Models;
using HRExpert.Organization.DTO;
using HRExpert.Organization.Data.Abstractions;
using ExtCore.Data.Abstractions;
using HRExpert.Organization.BL.Converters;
using System.IO;
using Platformus.Barebone;
using Platformus.Security;
using Platformus.Infrastructure;
namespace HRExpert.Organization.BL
{
    public class SicklistBL: BaseBL,Abstractions.ISicklistBL
    {
        private ISicklistRepository sicklistRepository;
        private IDocumentTypesRepository documentTypeRepository;
        private ISicklistBabyMindingTypesRepository sicklistBabyMindingTypesRepository;
        private ISicklistTypesRepository sicklistTypesRepository;
        private ISicklistPaymentRestrictTypesRepository sicklistPaymentRestrictTypesRepository;
        private ISicklistPaymentPercentRepository sicklistPaymentPercentRepository;
        private ITimesheetStatusRepository timesheetStatusRepository;
        private IPersonRepository personRepository;
        private ISignedFilesRepository signedFileRepository;
        
        public SicklistBL(Abstractions.IMainService mainService)
            :base(mainService)
        {
            this.sicklistRepository = mainService.Storage.GetRepository<ISicklistRepository>();
            this.documentTypeRepository = mainService.Storage.GetRepository<IDocumentTypesRepository>();
            this.personRepository = mainService.Storage.GetRepository<IPersonRepository>();
            this.sicklistBabyMindingTypesRepository = mainService.Storage.GetRepository<ISicklistBabyMindingTypesRepository>();
            this.sicklistPaymentPercentRepository = mainService.Storage.GetRepository<ISicklistPaymentPercentRepository>();
            this.sicklistPaymentRestrictTypesRepository = mainService.Storage.GetRepository<ISicklistPaymentRestrictTypesRepository>();
            this.sicklistTypesRepository = mainService.Storage.GetRepository<ISicklistTypesRepository>();
            this.timesheetStatusRepository = mainService.Storage.GetRepository<ITimesheetStatusRepository>();
            this.signedFileRepository = mainService.Storage.GetRepository<ISignedFilesRepository>();
            UserManager userManager = new UserManager(mainService);
            this.personRepository.CurrentUserId = userManager.GetCurrentUser().Id;
            this.sicklistRepository.CurrentUserId = userManager.GetCurrentUser().Id;
        }
        public List<DocumentDto<SicklistDto>> List()
        {
            return sicklistRepository.List().Select(x => x.Convert()).ToList();
        }
        public DocumentDto<SicklistDto> Read(int Id)
        {
            var document = this.sicklistRepository.Read(Id);
            var dto = document.Convert();
            dto.AvailableForRoles = this.sicklistRepository.GetResourceRoles(document.DocumentGuid);
            return dto;
        }                
        private void ChangeEntityProperties(Sicklist entity, DocumentDto<SicklistDto> dto)
        {
            var Person = entity.Document.Person==null? personRepository.Read(dto.Person.Id): entity.Document.Person;
            var CurrentPerson = personRepository.GetPersonByUserIdAndTargetDepartment(personRepository.CurrentUserId, Person.DepartmentId.Value);
            if (entity.Document.Creator == null) entity.Document.Creator = CurrentPerson;
            entity.PaymentDecreaseDate = dto.Data.PaymentDecreaseDate;
            entity.PaymentBeginDate = dto.Data.PaymentBeginDate;
            entity.isAddToFullPayment = dto.Data.isAddToFullPayment;
            entity.isPreviousPaymentCounted = dto.Data.isPreviousPaymentCounted;
            entity.isUseBefore = dto.Data.isUseBefore;
            entity.Document.Person = Person;
            entity.Document.DocumentType = documentTypeRepository.Read(1);
            entity.Document.CreateDate = DateTime.Now;
            if(entity.Document.Event==null) entity.Document.Event = new PersonEvent();
            entity.Document.Event.BeginDate = dto.Data.BeginDate;
            entity.Document.Event.EndDate = dto.Data.EndDate;
            if(entity.Document.Event.Timesheet==null) entity.Document.Event.Timesheet = new Timesheet();
            entity.Document.Event.Timesheet.IsStaffEstablishedPostTemporaryFree = false;

            if (dto.Data.TimesheetStatus != null && entity.Document.Event.Timesheet.StatusId!=dto.Data.TimesheetStatus.Id)                                
                entity.Document.Event.Timesheet.Status = timesheetStatusRepository.Read(dto.Data.TimesheetStatus.Id);

            if (dto.Data.SicklistBabyMindingType != null && entity.SicklistBabyMindingTypeId!=dto.Data.SicklistBabyMindingType.Id)
                entity.SicklistBabyMindingType = sicklistBabyMindingTypesRepository.Read(dto.Data.SicklistBabyMindingType.Id);

            if (dto.Data.SicklistPaymentPercent != null && entity.SicklistPaymentPercentId!=dto.Data.SicklistPaymentPercent.Id)
                entity.SicklistPaymentPercent = sicklistPaymentPercentRepository.Read(dto.Data.SicklistPaymentPercent.Id);

            if (dto.Data.SicklistPaymentRestrictType != null && entity.SicklistPaymentRestrictTypeId!= dto.Data.SicklistPaymentRestrictType.Id)
                entity.SicklistPaymentRestrictType = sicklistPaymentRestrictTypesRepository.Read(dto.Data.SicklistPaymentRestrictType.Id);

            if (dto.Data.SicklistType != null && entity.SicklistTypeId!=dto.Data.SicklistType.Id)
                entity.SicklistType = sicklistTypesRepository.Read(dto.Data.SicklistType.Id);
            entity.SicklistNumber = dto.Data.SicklistNumber;
            if(dto.Approvements!=null && dto.Approvements.Any())
            {
                if (entity.Document.Approvements == null) entity.Document.Approvements = new List<DocumentApprovement>();
                foreach(var element in dto.Approvements)
                {
                    if (element.isAccept)
                    {
                        //проверка прав
                        if (element.ApprovePosition == 1 && !handler.HttpContext.User.HasClaim("Permission","Табель.СогласованиеЗаСотрудника")) continue;
                        if (element.ApprovePosition == 2 && !handler.HttpContext.User.HasClaim("Permission", "Табель.СогласованиеЗаРуководителя")) continue;
                        if (element.ApprovePosition == 3 && !handler.HttpContext.User.HasClaim("Permission", "Табель.СогласованиеЗаКадровика")) continue;
                        DocumentApprovement approve = entity.Document.Approvements.FirstOrDefault(x => x.ApprovePosition == element.ApprovePosition);
                        if (approve == null) approve = new DocumentApprovement();
                        if (!approve.isAccept)
                        {
                            approve.ApprovePosition = element.ApprovePosition;
                            approve.DateAccept = DateTime.Now;
                            approve.isAccept = element.isAccept;
                            approve.RealPerson = CurrentPerson;
                            approve.Person = approve.Person != null ? approve.Person : CurrentPerson;
                            entity.Document.Approvements.Add(approve);
                        }
                    }
                }
            }
            if(dto.Data.SicklistDocument!=null)
            {
                //var dir = Path.Combine(this.authService.RootPath, "uploads");
                var filename = Guid.NewGuid().ToString();
                //if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                //var fs = new FileStream(Path.Combine(dir, filename), FileMode.Create);
                //dto.Data.SicklistDocument.CopyTo(fs);
                //fs.Flush();
                //entity.Document.Files.Add(new DocumentFile() { FileName = dto.Data.SicklistDocument.FileName, Path=Path.Combine("uploads",filename), FileType = 1 });
            }
        }
        public DocumentDto<SicklistDto> Create(DocumentDto<SicklistDto> dto)
        {            
            Sicklist entity = new Sicklist();
            entity.Document = new Document();

            ChangeEntityProperties(entity, dto);

            this.sicklistRepository.Create(entity);
            return entity.Convert();
        }
        public DocumentDto<SicklistDto> Update(DocumentDto<SicklistDto> dto)
        {
            var entity = sicklistRepository.Read(dto.Data.Id);

            ChangeEntityProperties(entity, dto);

            this.sicklistRepository.Update(entity);
            return entity.Convert();
        }

        //files 
        public Guid GetFileKey(int documentId, int filetype)
        {
            var doc = this.sicklistRepository.Read(documentId);
            var file = doc.Document.Files.FirstOrDefault(x => x.FileType == filetype);
            var signed = new SignedFile() { File = file, DeleteAfterDownload = true };
            if (file != null) this.signedFileRepository.Create(signed); return signed.Id;
            throw new FileNotFoundException("Файл не найден");
        }

    }
}
