using LDBookingApp.Models;
using LDBookingApp.Services.Navigation;
using LDBookingApp.Services.Programmes;
using MvvmHelpers.Commands;
using System.Threading.Tasks;

namespace LDBookingApp.ViewModels.Programmes
{
    public class DeleteProgrammeViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private IProgrammeDataService _programmeDataService;
        private Programme _selectedProgramme;

        public AsyncCommand DeleteProgrammeCommand { get; }
        public AsyncCommand RemovePopupCommand { get; }

        public Programme SelectedProgramme
        {
            get { return _selectedProgramme; }
            set
            {
                _selectedProgramme = value;
                OnPropertyChanged("SelectedProgramme");
            }
        }

        public DeleteProgrammeViewModel(INavigationService navigationService, IProgrammeDataService programmeDataService)
        {
            _navigationService = navigationService;
            _programmeDataService = programmeDataService;

            RemovePopupCommand = new AsyncCommand(() => RemovePopupCommandExecuted());
            DeleteProgrammeCommand = new AsyncCommand(() => DeleteCourseCommandExecuted());
        }

        public async Task RemovePopupCommandExecuted()
        {
            await _navigationService.RemovePopUp();
        }

        public async Task DeleteCourseCommandExecuted()
        {
            await _programmeDataService.RemoveProgramme(SelectedProgramme);
            await _navigationService.RemoveAllPopup();
        }

        public override void Initialize(object parameter)
        {
            if (parameter == null)
                SelectedProgramme = new Programme();
            else
                SelectedProgramme = parameter as Programme;
        }
    }
}
