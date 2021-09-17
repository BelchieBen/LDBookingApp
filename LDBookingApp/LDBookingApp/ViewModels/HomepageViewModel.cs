using LDBookingApp.Models;
using LDBookingApp.Services.Courses;
using LDBookingApp.Services.Dialogs;
using LDBookingApp.Services.Navigation;
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
        private ICourseDataService _courseDataService;
        private IDialogService _dialogService;
        private INavigationService _navigationService;

        public AsyncCommand AddCourseCommand { get; }
        public AsyncCommand ViewAllCoursesCommand { get; }
        public AsyncCommand<Course> CourseSelectedCommand { get; }

        public ObservableCollection<Course> Courses
        {
            get => _courses;
            set
            {
                _courses = value;
                OnPropertyChanged("Courses");
            }
        }

        public bool IsBusy { get; private set; }

        public HomepageViewModel(ICourseDataService courseDataService, IDialogService dialogService, INavigationService navigationService)
        {
            Courses = new ObservableCollection<Course>();
            _courseDataService = courseDataService;
            _dialogService = dialogService;
            _navigationService = navigationService;

            AddCourseCommand = new AsyncCommand(() => AddCourseCommandExecuted());
            ViewAllCoursesCommand = new AsyncCommand(() => ViewAllCoursesCommandExecuted());
            CourseSelectedCommand = new AsyncCommand<Course>((c) => CourseSelectedCommandExecuted(c));

            Task.Run(async () => await FetchCourses());
            _courseDataService.CourseUpdated += OnCourseUpdated;
        }

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
    }
}
