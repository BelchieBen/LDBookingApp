using LDBookingApp.Data.Programmes;
using LDBookingApp.Models;
using LDBookingApp.Services.Dialogs;
using LDBookingApp.Services.Navigation;
using LDBookingApp.Services.Programmes;
using LDBookingApp.Utility;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace LDBookingApp.ViewModels.Programmes
{
    public class ProgrammeViewAllPageViewModel : BaseViewModel
    {
        private ObservableCollection<Programme> _programmes;
        private IProgrammeDataStore _programmeDataStore;
        private IDialogService _dialogService;
        private INavigationService _navigationService;

        public AsyncCommand AddProgrammeCommand { get; }
        public AsyncCommand<Programme> ProgrammeSelectedCommand { get; }

        public ObservableCollection<Programme> Programmes
        {
            get => _programmes;
            set
            {
                _programmes = value;
                OnPropertyChanged("Programmes");
            }
        }

        public bool IsBusy { get; private set; }

        public ProgrammeViewAllPageViewModel(IProgrammeDataStore programmeDataStore,IDialogService dialogService, INavigationService navigationService)
        {
            Programmes = new ObservableCollection<Programme>();
            _programmeDataStore = programmeDataStore;
            _dialogService = dialogService;
            _navigationService = navigationService;

            AddProgrammeCommand = new AsyncCommand(() => AddProgrammeCommandExecuted());
            ProgrammeSelectedCommand = new AsyncCommand<Programme>((p) => ProgrammeSelectedCommandExecuted(p));
        }

        public async Task AddProgrammeCommandExecuted()
        {
            await _navigationService.PushPopUp(ViewNames.AddProgramme);
        }

        public async Task ProgrammeSelectedCommandExecuted(Programme p)
        {
            await _navigationService.PushPopUp(ViewNames.ViewProgramme);
        }
    }
}
