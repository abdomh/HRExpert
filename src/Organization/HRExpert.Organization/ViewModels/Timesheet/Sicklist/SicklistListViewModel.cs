namespace HRExpert.Organization.ViewModels
{
    public class SicklistListViewModel: DocumentsViewModelBase<DTO.DocumentDto<DTO.SicklistDto>,SicklistListFilterViewModel>
    {        
        public SicklistListViewModel()
        {
            this.Filter = new SicklistListFilterViewModel();
        }
    }
}
