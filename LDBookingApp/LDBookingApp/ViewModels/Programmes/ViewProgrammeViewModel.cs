using LDBookingApp.Data.Programmes;
using LDBookingApp.Models;
using LDBookingApp.Services.Navigation;
using LDBookingApp.Services.Programmes;
using LDBookingApp.Utility;
using MvvmHelpers.Commands;
using System.Threading.Tasks;

namespace LDBookingApp.ViewModels.Programmes
{
    public class ViewProgrammeViewModel : BaseViewModel
    {
        private Programme _selectedProgramme;
        private bool _editMode;
        private IProgrammeDataStore _programmeDataStore;
        private INavigationService _navigationService;

        public AsyncCommand ClosePopupCommand { get; }
        public Command EditModeCommand { get; }
        public AsyncCommand DeleteProgrammeCommand { get; }
        public AsyncCommand EditProgrammeCommand { get; }

        public Programme SelectedProgramme
        {
            get { return _selectedProgramme; }
            set
            {
                _selectedProgramme = value;
                OnPropertyChanged("SelectedProgramme");
            }
        }

        public bool EditMode
        {
            get => _editMode;
            set
            {
                _editMode = value;
                OnPropertyChanged("EditMode");
            }
        }

        public ViewProgrammeViewModel(IProgrammeDataStore programmeDataStore, INavigationService navigationService)
        {
            SelectedProgramme = new Programme();
            ClosePopupCommand = new AsyncCommand(() => ClosePopupCommandExecuted());
            EditModeCommand = new Command(() => EditModeCommandExecuted());
            DeleteProgrammeCommand = new AsyncCommand(() => DeleteProgrammeCommandExecuted());
            EditProgrammeCommand = new AsyncCommand(() => EditProgrammeCommandExecuted());

            _programmeDataStore = programmeDataStore;
            _navigationService = navigationService;
        }

        public async Task ClosePopupCommandExecuted()
        {
            await _navigationService.RemovePopUp();
        }

        public void EditModeCommandExecuted()
        {
            EditMode = !EditMode;
        }

        public async Task DeleteProgrammeCommandExecuted()
        {
            await _navigationService.PushPopUp(ViewNames.DeleteProgramme, SelectedProgramme);
        }

        public async Task EditProgrammeCommandExecuted()
        {
            await _programmeDataStore.UpdateProgrammeAsync(SelectedProgramme);
            await _navigationService.RemovePopUp();
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
