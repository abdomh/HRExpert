using System.Collections.Generic;
namespace HRExpert.Organization.BL
{
    using Data.Abstractions;
      
    public class ReferenceBL: BaseBL, Abstractions.IReferenceBL
    {
        private Dictionary<string, IReferenceRepository> referenceRepositories;
        private void RegisterReferency<T>(string name) where T : IReferenceRepository
        {
            this.referenceRepositories.Add(name, this.MainService.Storage.GetRepository<T>());
        }

        public ReferenceBL(Abstractions.IMainService mainService)
            :base(mainService)
        {
            this.referenceRepositories = new Dictionary<string, IReferenceRepository>();

            RegisterReferency<ISicklistTypesRepository>(ReferenceNames.SicklistTypes);
            RegisterReferency<ISicklistPaymentRestrictTypesRepository>(ReferenceNames.SicklistPaymentRestrictTypes);
            RegisterReferency<ISicklistPaymentPercentRepository>(ReferenceNames.SicklistPaymentPercent);
            RegisterReferency<ISicklistBabyMindingTypesRepository>(ReferenceNames.SicklistBabyMindingTypes);
            RegisterReferency<ITimesheetStatusRepository>(ReferenceNames.TimesheetStatus);
            RegisterReferency<IDocumentStatusRepository>(ReferenceNames.DocumentStatus);            
        }
        
        public List<Data.Models.Abstractions.IReference> List(string referenceName)
        {
            return this.referenceRepositories[referenceName].GetReferencies();
        }
    }
    public static class ReferenceNames
    {
        public const string SicklistTypes = "Справочник типы больничных листов";
        public const string SicklistPaymentRestrictTypes = "Справочник типы ограничений выплат";
        public const string SicklistPaymentPercent = "Справочник процентов выплат";
        public const string SicklistBabyMindingTypes = "Справочник типов больничных по уходу за ребенком";
        public const string TimesheetStatus = "Справочник статусов табеля";
        public const string SicklistStatus = "Справочник статусов больничных листов";
        public const string DocumentStatus = "Справочник статусов документа";
    }
}
