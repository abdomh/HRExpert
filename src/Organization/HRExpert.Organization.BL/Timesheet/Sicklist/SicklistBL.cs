﻿using System;
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

            UserManager userManager = new UserManager(mainService);
            this.personRepository.CurrentUserId = userManager.GetCurrentUser().Id;
            this.sicklistRepository.CurrentUserId = userManager.GetCurrentUser().Id;
        }
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
            dto.AvailableForRoles = this.sicklistRepository.GetResourceRoles(document.DocumentGuid);
            var persons = this.documentRepository.AvailableForPersons(document.DocumentGuid);
            var CurrentPerson = this.personRepository.GetCurrentPerson();
            var roles = this.documentRepository.AvailableForRoles(document.DocumentGuid, CurrentPerson.Id);
            var permissions = this.documentRepository.AvailablePermissions(document.DocumentGuid, CurrentPerson.Id);
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
                result = GetFile(file.Id.ToString());
                fileName = file.FileName;
            }
            return result;
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
            entity.Document.DocumentType = documentTypeRepository.WithCode("Sicklist");
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
                        if (element.ApprovePosition == 1 && !MainService.HttpContext.User.HasClaim("Permission","Табель.СогласованиеЗаСотрудника")) continue;
                        if (element.ApprovePosition == 2 && !MainService.HttpContext.User.HasClaim("Permission", "Табель.СогласованиеЗаРуководителя")) continue;
                        if (element.ApprovePosition == 3 && !MainService.HttpContext.User.HasClaim("Permission", "Табель.СогласованиеЗаКадровика")) continue;
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
                foreach(var file in entity.Document.Files.Where(x=>x.FileType==(int)FileTypesEnum.SicklistDocument))
                {
                    documentFilesRepository.Delete(file);
                }
                entity.Document.Files.Add(SaveFile(dto.Data.SicklistDocument, FileTypesEnum.SicklistDocument));
            }
        }
        public DocumentDto<SicklistDto> Create(DocumentDto<SicklistDto> dto)
        {            
            Sicklist entity = new Sicklist();
            entity.Document = new Document();

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

            ChangeEntityProperties(entity, dto);

            this.sicklistRepository.Update(entity);
            return entity.Convert();
        }

        

    }
}
