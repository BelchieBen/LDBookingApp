using LDBookingApp.ViewModels;
using LDBookingApp.ViewModels.Courses;
using LDBookingApp.ViewModels.Programmes;

namespace LDBookingApp.Utility
{
    public class ViewModelLocator
    {
        // General ViewModels
        public static HomepageViewModel HomepageViewModel { get; } = new HomepageViewModel(App.CourseDataService, App.DialogService, App.NavigationService, App.ProgrammeDataService);

        // Course ViewModels
        public static AddCourseViewModel AddCourseViewModel { get; } = new AddCourseViewModel(App.CourseDataService, App.NavigationService, App.ProgrammeDataService);
        public static ViewCourseViewModel ViewCourseViewModel { get; } = new ViewCourseViewModel(App.CourseDataService, App.NavigationService);
        public static DeleteCourseViewModel DeleteCourseViewModel { get; } = new DeleteCourseViewModel(App.NavigationService, App.CourseDataService);
        public static CoursesViewAllPageViewModel CoursesViewAllPageViewModel { get; } = new CoursesViewAllPageViewModel(App.CourseDataService, App.DialogService, App.NavigationService);

        // Programme ViewModels
        public static ProgrammeViewAllPageViewModel ProgrammeViewAllPageViewModel { get; } = new ProgrammeViewAllPageViewModel(App.ProgrammeDataService, App.DialogService, App.NavigationService);
        public static AddProgrammeViewModel AddProgrammeViewModel { get; } = new AddProgrammeViewModel(App.ProgrammeDataService, App.NavigationService);
        public static ViewProgrammeViewModel ViewProgrammeViewModel { get; } = new ViewProgrammeViewModel(App.ProgrammeDataService, App.NavigationService);
        public static DeleteProgrammeViewModel DeleteProgrammeViewModel { get; } = new DeleteProgrammeViewModel(App.NavigationService, App.ProgrammeDataService);
    }
}
