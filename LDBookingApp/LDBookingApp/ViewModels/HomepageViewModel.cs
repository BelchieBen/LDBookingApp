using LDBookingApp.Models;
using LDBookingApp.Services.Courses;
using LDBookingApp.Services.Dialogs;
using LDBookingApp.Services.Navigation;
using LDBookingApp.Services.Programmes;
using LDBookingApp.Utility;
using MvvmHelpers.Commands;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace LDBookingApp.ViewModels
{
    public class HomepageViewModel : BaseViewModel
    {
        private ObservableCollection<Course> _courses;
        private ObservableCollection<Programme> _programmes;
        private ICourseDataService _courseDataService;
        private IProgrammeDataService _programmeDataService;
        private IDialogService _dialogService;
        private INavigationService _navigationService;

        // Course Commands
        public AsyncCommand AddCourseCommand { get; }
        public AsyncCommand ViewAllCoursesCommand { get; }
        public AsyncCommand<Course> CourseSelectedCommand { get; }

        // Programme Commands
        public AsyncCommand AddProgrammeCommand { get; }
        public AsyncCommand ViewAllProgrammesCommand { get; }
        public AsyncCommand<Programme> ProgrammeSelectedCommand { get; }

        public ObservableCollection<Course> Courses
        {
            get => _courses;
            set
            {
                _courses = value;
                OnPropertyChanged("Courses");
            }
        }

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

        public HomepageViewModel(ICourseDataService courseDataService, IDialogService dialogService, INavigationService navigationService, IProgrammeDataService programmeDataService)
        {
            Courses = new ObservableCollection<Course>();
            _courseDataService = courseDataService;
            _dialogService = dialogService;
            _navigationService = navigationService;
            _programmeDataService = programmeDataService;

            AddCourseCommand = new AsyncCommand(() => AddCourseCommandExecuted());
            ViewAllCoursesCommand = new AsyncCommand(() => ViewAllCoursesCommandExecuted());
            CourseSelectedCommand = new AsyncCommand<Course>((c) => CourseSelectedCommandExecuted(c));

            AddProgrammeCommand = new AsyncCommand(() => AddProgrammeCommandExecuted());
            ViewAllProgrammesCommand = new AsyncCommand(() => ViewAllProgrammesCommandExecuted());
            ProgrammeSelectedCommand = new AsyncCommand<Programme>((p) => ProgrammeSelectedCommandExecuted(p));

            Task.Run(async () => await FetchCourses());
            Task.Run(async () => await FetchProgrammes());
            _courseDataService.CourseUpdated += OnCourseUpdated;
            _programmeDataService.ProgrammeUpdated += OnProgrammeUpdated;
        }

        #region Courses

        public async void OnCourseUpdated(object sender, EventArgs e)
        {
            await FetchCourses();
        }

        private async Task FetchCourses()
        {
            try
            {
                IsBusy = true;
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.None)
                {
                    await _dialogService.ShowDialogAsync(Strings.No_Connection, Strings.Refresh_error, Strings.Ok);
                }
                else
                {
                    Courses = new ObservableCollection<Course>(await _courseDataService.GetTopCourses());
                }
            }
            catch
            {

            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task AddCourseCommandExecuted()
        {
            await _navigationService.PushPopUp(ViewNames.AddCourse);
        }

        public async Task ViewAllCoursesCommandExecuted()
        {
            await _navigationService.GoTo(ViewNames.ViewAllCourses);
        }

        public async Task CourseSelectedCommandExecuted(Course c)
        {
            await _navigationService.PushPopUp(ViewNames.ViewCourse, c);
        }

        #endregion

        #region Programmes

        private async void OnProgrammeUpdated(object sender, EventArgs e)
        {
            await FetchProgrammes();
        }

        private async Task FetchProgrammes()
        {
            try
            {
                IsBusy = true;
                var current = Connectivity.NetworkAccess;
                if (current == NetworkAccess.None)
                {
                    await _dialogService.ShowDialogAsync(Strings.No_Connection, Strings.Refresh_error, Strings.Ok);
                }
                else
                {
                    Programmes = new ObservableCollection<Programme>(await _programmeDataService.GetTopProgrammes());
                }
            }
            catch
            {

            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task AddProgrammeCommandExecuted()
        {
            await _navigationService.PushPopUp(ViewNames.AddProgramme);
        }

        public async Task ViewAllProgrammesCommandExecuted()
        {
            await _navigationService.GoTo(ViewNames.ViewAllProgramme);
        }

        public async Task ProgrammeSelectedCommandExecuted(Programme p)
        {
            await _navigationService.PushPopUp(ViewNames.ViewProgramme, p);
        }

        #endregion 
    }
}
