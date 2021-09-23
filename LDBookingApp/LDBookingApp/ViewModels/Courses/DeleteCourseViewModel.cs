using LDBookingApp.Models;
using LDBookingApp.Services.Courses;
using LDBookingApp.Services.Navigation;
using LDBookingApp.Utility;
using MvvmHelpers.Commands;
using System.Threading.Tasks;

namespace LDBookingApp.ViewModels.Courses
{
    public class DeleteCourseViewModel : BaseViewModel
    {
        private INavigationService _navigationService;
        private ICourseDataService _courseDataService;
        private Course _selectedCourse;

        public AsyncCommand DeleteCourseCommand { get; }
        public AsyncCommand RemovePopupCommand { get; }

        public Course SelectedCourse
        {
            get { return _selectedCourse; }
            set
            {
                _selectedCourse = value;
                OnPropertyChanged("SelectedCourse");
            }
        }

        public DeleteCourseViewModel(INavigationService navigationService, ICourseDataService courseDataService)
        {
            _navigationService = navigationService;
            _courseDataService = courseDataService;

            RemovePopupCommand = new AsyncCommand(() => RemovePopupCommandExecuted());
            DeleteCourseCommand = new AsyncCommand(() => DeleteCourseCommandExecuted());
        }

        public async Task RemovePopupCommandExecuted()
        {
            await _navigationService.RemovePopUp();
        }

        public async Task DeleteCourseCommandExecuted()
        {
            await _courseDataService.DeleteCourse(SelectedCourse);
            await _navigationService.RemoveAllPopup();
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
