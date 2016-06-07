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
            dto.PostCount = entity.PostCount;
            dto.StaffEstablishedPost = entity.StaffEstablishedPost.Convert();
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
        private static DocumentDto<T> GetDocumentDto<T>(this Document entity)
        {
            DocumentDto<T> dto = new DocumentDto<T>();
            dto.CreateDate = entity.CreateDate;
            dto.Creator = entity.Creator.Convert();
            dto.DocumentType = entity.DocumentType.Convert();
            dto.Person = entity.Person.Convert();
            return dto;
        }
        public static DocumentDto<SicklistDto> Convert(this Sicklist entity)
        {
            if (entity == null) return null;
            DocumentDto<SicklistDto> dto = entity.Document.GetDocumentDto<SicklistDto>();
            SicklistDto data = new SicklistDto();
            data.Id = entity.Id;
            data.SicklistBabyMindingType = entity.SicklistBabyMindingType.Convert();
            data.SicklistPaymentPercent = entity.SicklistPaymentPercent.Convert();
            data.SicklistPaymentRestrictType = entity.SicklistPaymentRestrictType.Convert();
            data.TimesheetStatus = entity.Document.Event?.Timesheet?.Status.Convert();
            data.BeginDate = entity.Document.Event?.BeginDate;
            data.EndDate = entity.Document.Event?.EndDate;
            data.SicklistNumber = entity.SicklistNumber;
            data.Type = entity.SicklistType.Convert();
            dto.Data = data;
            return dto;
        }
    }
}
