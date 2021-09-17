using LDBookingApp.ViewModels;
using LDBookingApp.ViewModels.Courses;

namespace LDBookingApp.Utility
{
    public class ViewModelLocator
    {
        public static HomepageViewModel HomepageViewModel { get; } = new HomepageViewModel(App.CourseDataService, App.DialogService, App.NavigationService);
        public static AddCourseViewModel AddCourseViewModel { get; } = new AddCourseViewModel(App.CourseDataService, App.NavigationService);
        public static ViewCourseViewModel ViewCourseViewModel { get; } = new ViewCourseViewModel(App.CourseDataService, App.NavigationService);
        public static DeleteCourseViewModel DeleteCourseViewModel { get; } = new DeleteCourseViewModel(App.NavigationService, App.CourseDataService);
        public static CoursesViewAllPageViewModel CoursesViewAllPageViewModel { get; } = new CoursesViewAllPageViewModel(App.CourseDataService, App.DialogService, App.NavigationService);
    }
}
