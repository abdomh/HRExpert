namespace HRExpert.Organization.ViewModels
{
    public class CalendarViewModel: DocumentsViewModelBase<DTO.CalendarDto,CalendarFilterViewModel>
    {        
        public CalendarViewModel()
        {
            this.Filter = new CalendarFilterViewModel();
        }
    }
}
