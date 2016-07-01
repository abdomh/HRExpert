using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRExpert.Organization.Data.Models;
using HRExpert.Organization.DTO;
using HRExpert.Core.Services.Abstractions;
using HRExpert.Core.Data.Models;
using HRExpert.Organization.Data.Abstractions;
using ExtCore.Data.Abstractions;
using HRExpert.Organization.BL.Converters;
using System.IO;
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
        private ISignedFilesRepository signedFileRepository;
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
            this.signedFileRepository = storage.GetRepository<ISignedFilesRepository>();
            this.personRepository.CurrentRoleId = authService.CurrentRoleId;
            this.personRepository.CurrentUserId = authService.CurrentUser.Id;
            this.sicklistRepository.CurrentRoleId = authService.CurrentRoleId;
            this.sicklistRepository.CurrentUserId = authService.CurrentUser.Id;
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
        private void ChangeEntityProperties(Sicklist entity, DocumentDto<SicklistDto> dto)
        {
            var Person = entity.Document.Person==null? personRepository.Read(dto.Person.Id): entity.Document.Person;
            var CurrentPerson = personRepository.GetPersonByUserIdAndTargetDepartment(authService.CurrentUser.Id, Person.DepartmentId.Value);
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
                        if (element.ApprovePosition == 1 && !authService.CheckPermission((long)PermissionEnum.TimesheetApproveEmployee)) continue;
                        if (element.ApprovePosition == 2 && !authService.CheckPermission((long)PermissionEnum.TimesheetApproveManager)) continue;
                        if (element.ApprovePosition == 3 && !authService.CheckPermission((long)PermissionEnum.TimesheetApprovePersonnelManager)) continue;
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
                var dir = Path.Combine(this.authService.RootPath, "uploads");
                var filename = Guid.NewGuid().ToString();
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                var fs = new FileStream(Path.Combine(dir, filename), FileMode.Create);
                dto.Data.SicklistDocument.CopyTo(fs);
                fs.Flush();
                entity.Document.Files.Add(new DocumentFile() { FileName = dto.Data.SicklistDocument.FileName, Path=Path.Combine("uploads",filename), FileType = 1 });
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
        public Guid GetFileKey(long documentId, int filetype)
        {
            var doc = this.sicklistRepository.Read(documentId);
            var file = doc.Document.Files.FirstOrDefault(x => x.FileType == filetype);
            var signed = new SignedFile() { File = file, DeleteAfterDownload = true };
            if (file != null) this.signedFileRepository.Create(signed); return signed.Id;
            throw new FileNotFoundException("Файл не найден");
        }

    }
}
