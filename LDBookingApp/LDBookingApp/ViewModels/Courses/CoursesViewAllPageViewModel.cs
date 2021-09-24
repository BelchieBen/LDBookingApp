using LDBookingApp.Data.Courses;
using LDBookingApp.Models;
using LDBookingApp.Services.Courses;
using LDBookingApp.Services.Dialogs;
using LDBookingApp.Services.Navigation;
using LDBookingApp.Utility;
using MvvmHelpers.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace LDBookingApp.ViewModels.Courses
{
    public class CoursesViewAllPageViewModel : BaseViewModel
    {
        private ObservableCollection<Course> _courses;
        private ICourseDataStore _courseDataStore;
        private IDialogService _dialogService;
        private INavigationService _navigationService;

        public AsyncCommand AddCourseCommand { get; }
        public AsyncCommand<Course> UpdateCourseCommand { get; }
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

        public CoursesViewAllPageViewModel(ICourseDataStore courseDataStore, IDialogService dialogService, INavigationService navigationService)
        {
            Courses = new ObservableCollection<Course>();
            _courseDataStore = courseDataStore;
            _dialogService = dialogService;
            _navigationService = navigationService;

            AddCourseCommand = new AsyncCommand(() => AddCourseCommandExecuted());
            CourseSelectedCommand = new AsyncCommand<Course>((c) => CourseSelectedCommandExecuted(c));
            UpdateCourseCommand = new AsyncCommand<Course>((c) => UpdateCourseCommandExecuted(c));

            Task.Run(async () => await FetchCourses());
            _courseDataStore.CourseUpdated += OnCourseUpdated;
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
                    Courses = new ObservableCollection<Course>(await _courseDataStore.GetCoursesAsync());
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

        public async Task CourseSelectedCommandExecuted(Course c)
        {
            await _navigationService.PushPopUp(ViewNames.ViewCourse, c);
        }
        public async Task UpdateCourseCommandExecuted(Course c)
        {
            await _navigationService.PushPopUp(ViewNames.ViewCourse, c);
        }
    }
}
