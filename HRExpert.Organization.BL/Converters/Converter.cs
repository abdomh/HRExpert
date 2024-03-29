﻿using System.Linq;
using HRExpert.Organization.Data.Models;
using HRExpert.Organization.DTO;
namespace HRExpert.Organization.BL.Converters
{
    public static class Converter
    {
        public static OrganizationDto Convert(this Data.Models.Organization entity)
        {
            if (entity == null) return null;
            OrganizationDto dto = new OrganizationDto();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            return dto;
        }
        public static DepartmentDto Convert(this Department entity)
        {
            if (entity == null) return null;
            DepartmentDto dto = new DepartmentDto();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.ParentId = entity.ParentId.HasValue?entity.ParentId.Value:0;
            dto.Organization = entity.Organization.Convert();
            return dto;
        }
        public static PositionDto Convert(this Position entity)
        {
            if (entity == null) return null;
            PositionDto dto = new PositionDto();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            return dto;
        }
        public static StaffEstablishedPostDto Convert(this StaffEstablishedPost entity)
        {
            if (entity == null) return null;
            StaffEstablishedPostDto dto = new StaffEstablishedPostDto();
            dto.PostCount = entity.PostCount;
            dto.Position = entity.Position.Convert();
            dto.Department = entity.Department.Convert();
            return dto;
        }
        public static PersonDto Convert(this Person entity)
        {
            if (entity == null) return null;
            PersonDto dto = new PersonDto();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.PostCount = entity.PostCount.HasValue?entity.PostCount.Value:0;
            dto.StaffEstablishedPost = entity.StaffEstablishedPost.Convert();
            return dto;
        }
        public static DocumentApprovementDto Convert(this DocumentApprovement entity)
        {
            if (entity == null) return null;
            DocumentApprovementDto dto = new DocumentApprovementDto();
            dto.ApprovePosition = entity.ApprovePosition;
            dto.DateAccept = entity.DateAccept;
            dto.Person = entity.Person.Convert();
            dto.RealPerson = entity.RealPerson.Convert();
            dto.isAccept = entity.isAccept;
            return dto;
        }
        public static DocumentTypeDto Convert(this DocumentType entity)
        {
            if (entity == null) return null;
            DocumentTypeDto dto = new DocumentTypeDto();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            return dto;
        }
        public static PersonEventDto Convert(this PersonEvent entity)
        {
            if (entity == null) return null;
            PersonEventDto dto = new PersonEventDto();
            dto.BeginDate = entity.BeginDate;
            dto.EndDate = entity.EndDate;
            dto.Name = entity.Document?.DocumentType?.Name + " " + entity.Document?.DocumentId;
            return dto;
        }
        public static TimesheetDto Convert(this Timesheet entity)
        {
            if (entity == null) return null;
            TimesheetDto dto = new TimesheetDto();
            dto.Event = entity.Event.Convert();
            dto.Status = entity.Status.Convert();
            return dto;
        }
        public static TimesheetStatusDto Convert(this TimesheetStatus entity)
        {
            if (entity == null) return null;
            TimesheetStatusDto dto = new TimesheetStatusDto();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.ShortName = entity.ShortName;
            return dto;
        }
        public static SicklistTypeDto Convert(this SicklistType entity)
        {
            if (entity == null) return null;
            SicklistTypeDto dto = new SicklistTypeDto();
            dto.Name = entity.Name;
            dto.Id = entity.Id;
            return dto;
        }
        public static SicklistPaymentPercentDto Convert(this SicklistPaymentPercent entity)
        {
            if (entity == null) return null;
            SicklistPaymentPercentDto dto = new SicklistPaymentPercentDto();
            dto.Id = entity.Id;
            dto.Value = entity.Value;
            return dto;
        }
        public static SicklistPaymentRestrictTypeDto Convert(this SicklistPaymentRestrictType entity)
        {
            if (entity == null) return null;
            SicklistPaymentRestrictTypeDto dto = new SicklistPaymentRestrictTypeDto();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            dto.Value = entity.Value;
            return dto;
        }
        public static SicklistBabyMindingTypeDto Convert(this SicklistBabyMindingType entity)
        {
            if (entity == null) return null;
            SicklistBabyMindingTypeDto dto = new SicklistBabyMindingTypeDto();
            dto.Id = entity.Id;
            dto.Name = entity.Name;
            return dto;
        }
        private static DocumentDto<T> GetDocumentDto<T>(Document entity)
        {
            DocumentDto<T> dto = new DocumentDto<T>();
            dto.Person = entity.Person.Convert();
            dto.Creator = entity.Creator.Convert();
            dto.CreateDate = entity.CreateDate;
            dto.DocumentType = entity.DocumentType.Convert();
            if (entity.Approvements != null && entity.Approvements.Any())
                dto.Approvements = entity.Approvements.Select(x => x.Convert()).ToArray();
            if (entity.Files != null && entity.Files.Count > 0)
                dto.Files = entity.Files.Select(x => x.Convert()).ToArray();
            return dto;
        }
        public static DocumentDto<SicklistDto> Convert(this Sicklist entity)
        {
            if (entity == null) return null;
            SicklistDto data = new SicklistDto();
            var doc = GetDocumentDto<SicklistDto>(entity.Document);
            
            data.Id = entity.Id;
            data.SicklistBabyMindingType = entity.SicklistBabyMindingType.Convert();
            data.SicklistPaymentPercent = entity.SicklistPaymentPercent.Convert();
            data.SicklistPaymentRestrictType = entity.SicklistPaymentRestrictType.Convert();
            data.TimesheetStatus = entity.Document.Event?.Timesheet?.Status.Convert();
            data.BeginDate = entity.Document.Event?.BeginDate;
            data.EndDate = entity.Document.Event?.EndDate;
            data.SicklistNumber = entity.SicklistNumber;
            data.SicklistType = entity.SicklistType.Convert();
            data.ExperienceMonth = entity.ExperienceMonth;
            data.ExperienceYears = entity.ExperienceYears;
            data.isAddToFullPayment = entity.isAddToFullPayment;
            data.isPreviousPaymentCounted = entity.isPreviousPaymentCounted;
            data.isUseBefore = entity.isUseBefore;
            data.PaymentBeginDate = entity.PaymentBeginDate;
            data.PaymentDecreaseDate = entity.PaymentDecreaseDate;            
            doc.Data = data;
            return doc;
        }
        public static FileDto Convert(this DocumentFile entity)
        {
            var dto = new FileDto();
            dto.FileName = entity.FileName;
            dto.FileType = entity.FileType;
            return dto;
        }
    }
}
