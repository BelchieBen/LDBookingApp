using LDBookingApp.Models;
using LDBookingApp.Services.Courses;
using LDBookingApp.Services.Navigation;
using LDBookingApp.Utility;
using MvvmHelpers.Commands;
using System;
using System.Threading.Tasks;

namespace LDBookingApp.ViewModels.Courses
{
    public class ViewCourseViewModel : BaseViewModel
    {
        private Course _selectedCourse;
        private bool _editMode;
        private ICourseDataService _courseDataService;
        private INavigationService _navigationService;

        public AsyncCommand ClosePopupCommand { get; }
        public Command EditCourseCommand { get; }
        public AsyncCommand DeleteCourseCommand { get; }
        public AsyncCommand UpdateCourseCommand { get; }

        public Course SelectedCourse
        {
            get { return _selectedCourse; }
            set
            {
                _selectedCourse = value;
                OnPropertyChanged("SelectedCourse");
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

        public ViewCourseViewModel(ICourseDataService courseDataService, INavigationService navigationService)
        {
            _courseDataService = courseDataService;
            _navigationService = navigationService;

            SelectedCourse = new Course();
            ClosePopupCommand = new AsyncCommand(() => ClosePopupCommandExecuted());
            EditCourseCommand = new Command(() => EditCourseCommandExecuted());
            DeleteCourseCommand = new AsyncCommand(() => DeleteCourseCommandExecuted());
            UpdateCourseCommand = new AsyncCommand(() => UpdateCourseCommandExecuted());
        }

        public async Task ClosePopupCommandExecuted()
        {
            await _navigationService.RemovePopUp();
        }

        public void EditCourseCommandExecuted()
        {
            EditMode = !EditMode;
        }
        public async Task DeleteCourseCommandExecuted()
        {
            await _navigationService.PushPopUp(ViewNames.DeleteCourse, SelectedCourse);
        }

        public async Task UpdateCourseCommandExecuted()
        {
            await _courseDataService.UpdateCourse(SelectedCourse);
            await _navigationService.RemovePopUp();
        }

        public override void Initialize(object parameter)
        {
            if (parameter == null)
                SelectedCourse = new Course();
            else
                SelectedCourse = parameter as Course;
        }
    }
}
