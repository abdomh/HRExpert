using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        #region Private fields
        private ISicklistRepository sicklistRepository;
        private IDocumentTypesRepository documentTypeRepository;
        private ISicklistBabyMindingTypesRepository sicklistBabyMindingTypesRepository;
        private ISicklistTypesRepository sicklistTypesRepository;
        private ISicklistPaymentRestrictTypesRepository sicklistPaymentRestrictTypesRepository;
        private ISicklistPaymentPercentRepository sicklistPaymentPercentRepository;
        private ITimesheetStatusRepository timesheetStatusRepository;
        private IPersonRepository personRepository;        
        private IDocumentFilesRepository documentFilesRepository;
        private IDocumentRepository documentRepository;
        private IDocumentStatusRepository documentStatusRepository;
        #endregion
        #region Private methods
        private void SetFlagState(Guid Id, DocumentDto<SicklistDto> dto)
        {
            var CurrentPerson = this.personRepository.GetCurrentPerson();
            var permissions = this.documentRepository.AvailablePermissions(Id, CurrentPerson.Id)?.Select(x => x.Code);
            if (permissions == null) return;
            dto.ResourcePermissions = permissions;
            switch (dto.Data.SicklistStatusId)
            {
                case 1:
                    dto.IsEditable = permissions.Contains("Request.Edit.Employee");
                    break;
                case 2:
                    dto.IsEditable = permissions.Contains("Request.Edit.Manager");
                    break;
                case 3:
                    dto.IsEditable = permissions.Contains("Request.Edit.PersonnelManager");
                    break;
                default: break;
            }

        }
        private void SetApprovements(Sicklist entity, DocumentDto<SicklistDto> dto, Person currentPerson)
        {
            if (dto.Approvements != null && dto.Approvements.Any())
            {
                if (entity.Document.Approvements == null) entity.Document.Approvements = new List<DocumentApprovement>();
                foreach (var element in dto.Approvements)
                {
                    if (element.isAccept)
                    {
                        DocumentApprovement approve = entity.Document.Approvements.FirstOrDefault(x => x.ApprovePosition == element.ApprovePosition);
                        if (approve == null) approve = new DocumentApprovement();
                        if (!approve.isAccept)
                        {
                            approve.ApprovePosition = element.ApprovePosition;
                            approve.DateAccept = DateTime.Now;
                            approve.isAccept = element.isAccept;
                            approve.RealPerson = currentPerson;
                            approve.Person = approve.Person != null ? approve.Person : currentPerson;
                            entity.Document.Approvements.Add(approve);
                        }
                    }
                }
            }
        }
        private void SetEntityStatus(Sicklist entity)
        {
            //статус заявки
            var EmployeeApprove = entity.Document.Approvements?.FirstOrDefault(x => x.ApprovePosition == 1);
            var ManagerApprove = entity.Document.Approvements?.FirstOrDefault(x => x.ApprovePosition == 2);
            var PersonnelManagerApprove = entity.Document.Approvements?.FirstOrDefault(x => x.ApprovePosition == 3);
            if (EmployeeApprove != null && EmployeeApprove.isAccept) entity.StatusId = (int)ApproveProgressStatusEnum.ApprovedByEmployee;
            if (ManagerApprove != null && ManagerApprove.isAccept) entity.StatusId = (int)ApproveProgressStatusEnum.ApprovedByManager;
            if (PersonnelManagerApprove != null && PersonnelManagerApprove.isAccept) entity.StatusId = (int)ApproveProgressStatusEnum.ApprovedByPersonnelManager;
            //Статус документа
            entity.Document.Status = this.documentStatusRepository.WithCode("Draft");
            if (entity.StatusId >= (int)ApproveProgressStatusEnum.ApprovedByEmployee)
            {
                entity.Document.Status = this.documentStatusRepository.WithCode("WorkInProgress");
            }
            if ( entity.StatusId == (int)ApproveProgressStatusEnum.ApprovedByPersonnelManager)
            {
                entity.Document.Status = this.documentStatusRepository.WithCode("Approved");
            }
        }

        private void ChangeEntityProperties(Sicklist entity, DocumentDto<SicklistDto> dto)
        {
            var Person = entity.Document.Person == null ? personRepository.Read(dto.Person.Id) : entity.Document.Person;
            var CurrentPerson = personRepository.GetPersonByUserIdAndTargetDepartment(personRepository.CurrentUserId, Person.DepartmentId.Value);
            if (entity.Document.Creator == null) entity.Document.Creator = CurrentPerson;
            entity.PaymentDecreaseDate = dto.Data.PaymentDecreaseDate;
            entity.PaymentBeginDate = dto.Data.PaymentBeginDate;
            entity.isAddToFullPayment = dto.Data.isAddToFullPayment;
            entity.isPreviousPaymentCounted = dto.Data.isPreviousPaymentCounted;
            entity.isUseBefore = dto.Data.isUseBefore;
            entity.IsContinued = dto.Data.IsContinue;
            entity.Document.Person = Person;
            entity.Document.DocumentType = documentTypeRepository.WithCode("Sicklist");
            entity.Document.CreateDate = DateTime.Now;
            if (entity.Document.Event == null) entity.Document.Event = new PersonEvent();
            entity.Document.Event.BeginDate = dto.Data.BeginDate;
            entity.Document.Event.EndDate = dto.Data.EndDate;
            if (entity.Document.Event.Timesheet == null) entity.Document.Event.Timesheet = new Timesheet();
            entity.Document.Event.Timesheet.IsStaffEstablishedPostTemporaryFree = false;

            if (dto.Data.TimesheetStatus != null && entity.Document.Event.Timesheet.StatusId != dto.Data.TimesheetStatus.Id)
                entity.Document.Event.Timesheet.Status = timesheetStatusRepository.Read(dto.Data.TimesheetStatus.Id);

            if (dto.Data.SicklistBabyMindingType != null && entity.SicklistBabyMindingTypeId != dto.Data.SicklistBabyMindingType.Id)
                entity.SicklistBabyMindingType = sicklistBabyMindingTypesRepository.Read(dto.Data.SicklistBabyMindingType.Id);

            if (dto.Data.SicklistPaymentPercent != null && entity.SicklistPaymentPercentId != dto.Data.SicklistPaymentPercent.Id)
                entity.SicklistPaymentPercent = sicklistPaymentPercentRepository.Read(dto.Data.SicklistPaymentPercent.Id);

            if (dto.Data.SicklistPaymentRestrictType != null && entity.SicklistPaymentRestrictTypeId != dto.Data.SicklistPaymentRestrictType.Id)
                entity.SicklistPaymentRestrictType = sicklistPaymentRestrictTypesRepository.Read(dto.Data.SicklistPaymentRestrictType.Id);

            if (dto.Data.SicklistType != null && entity.SicklistTypeId != dto.Data.SicklistType.Id)
                entity.SicklistType = sicklistTypesRepository.Read(dto.Data.SicklistType.Id);
            entity.SicklistNumber = dto.Data.SicklistNumber;

            SetApprovements(entity,dto,CurrentPerson);
            SetEntityStatus(entity);

            if (dto.Data.SicklistDocument != null)
            {
                foreach (var file in entity.Document.Files.Where(x => x.FileType == (int)FileTypesEnum.SicklistDocument))
                {
                    documentFilesRepository.Delete(file);
                }
                entity.Document.Files.Add(SaveFile(dto.Data.SicklistDocument, FileTypesEnum.SicklistDocument));
            }
        }
        #endregion

        #region Ctor
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
            this.documentFilesRepository = mainService.Storage.GetRepository<IDocumentFilesRepository>();
            this.documentRepository = mainService.Storage.GetRepository<IDocumentRepository>();
            this.documentStatusRepository = mainService.Storage.GetRepository<IDocumentStatusRepository>();
            
            this.personRepository.CurrentUserId = mainService.CurrentUserId;
            this.sicklistRepository.CurrentUserId = mainService.CurrentUserId;
        }
        #endregion

        #region Public methods
        public List<DocumentDto<SicklistDto>> GetByFilterModel(object filterModel)
        {
            var filter = ContentFilterFactory.Create<Sicklist>(filterModel);
            return this.List(filter);
        }
        public List<DocumentDto<SicklistDto>> List()
        {
            return sicklistRepository.List().Select(x => x.Convert()).ToList();
        }
        public List<DocumentDto<SicklistDto>> List(Expression<Func<Sicklist,bool>> filter)
        {
            return sicklistRepository.List(filter).Select(x => x.Convert()).ToList();
        }
        public DocumentDto<SicklistDto> Read(int Id)
        {
            var document = this.sicklistRepository.Read(Id);            
            var dto = document.Convert();
            SetFlagState(document.DocumentGuid, dto);            
            return dto;
        }                
        
        public byte[] GetFile(int SicklistId, int FileType, out string fileName)
        {
            fileName = "document";
            byte[] result = null;
            var entity = sicklistRepository.Read(SicklistId);
            var file = entity.Document.Files.FirstOrDefault(x => x.FileType == FileType);
            if (file != null)
            {
                result = GetFile(file.Path);
                fileName = file.FileName;
            }
            return result;
        }
        
        public DocumentDto<SicklistDto> Create(DocumentDto<SicklistDto> dto)
        {            
            Sicklist entity = new Sicklist();
            entity.Document = new Document();
            entity.Document.Approvements = new List<DocumentApprovement>();

            entity.Document.Approvements.Add(new DocumentApprovement() { Document = entity.Document, ApprovePosition = 1 });
            entity.Document.Approvements.Add(new DocumentApprovement() { Document = entity.Document, ApprovePosition = 2 });
            entity.Document.Approvements.Add(new DocumentApprovement() { Document = entity.Document, ApprovePosition = 3 });

            entity.StatusId = (int)ApproveProgressStatusEnum.NotApproved;
            ChangeEntityProperties(entity, dto);
            entity.Document.DocumentType = documentTypeRepository.WithCode("Sicklist");
            this.sicklistRepository.Create(entity);
            entity.Document.DocumentId = entity.Id;
            this.sicklistRepository.Update(entity);
            return entity.Convert();
        }
        public DocumentDto<SicklistDto> Update(DocumentDto<SicklistDto> dto)
        {
            var entity = sicklistRepository.Read(dto.Data.Id);
            dto.Data.SicklistStatusId = entity.StatusId;
            SetFlagState(entity.DocumentGuid,dto);
            if (dto.IsEditable)
            {
                ChangeEntityProperties(entity, dto);
                this.sicklistRepository.Update(entity);
            }
            return entity.Convert();
        }
        #endregion
    }
}
