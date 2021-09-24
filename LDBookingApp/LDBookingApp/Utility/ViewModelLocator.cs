using LDBookingApp.ViewModels;
using LDBookingApp.ViewModels.Courses;
using LDBookingApp.ViewModels.Programmes;

namespace LDBookingApp.Utility
{
    public class ViewModelLocator
    {
        // General ViewModels
        public static HomepageViewModel HomepageViewModel { get; } = new HomepageViewModel(App.CourseDataStore, App.DialogService, App.NavigationService, App.ProgrammeDataStore);

        // Course ViewModels
        public static AddCourseViewModel AddCourseViewModel { get; } = new AddCourseViewModel(App.NavigationService, App.ProgrammeDataService, App.CourseDataStore);
        public static ViewCourseViewModel ViewCourseViewModel { get; } = new ViewCourseViewModel(App.CourseDataStore, App.NavigationService);
        public static DeleteCourseViewModel DeleteCourseViewModel { get; } = new DeleteCourseViewModel(App.NavigationService, App.CourseDataStore);
        public static CoursesViewAllPageViewModel CoursesViewAllPageViewModel { get; } = new CoursesViewAllPageViewModel(App.CourseDataStore, App.DialogService, App.NavigationService);

        // Programme ViewModels
        public static ProgrammeViewAllPageViewModel ProgrammeViewAllPageViewModel { get; } = new ProgrammeViewAllPageViewModel(App.ProgrammeDataStore, App.DialogService, App.NavigationService);
        public static AddProgrammeViewModel AddProgrammeViewModel { get; } = new AddProgrammeViewModel(App.ProgrammeDataStore, App.NavigationService);
        public static ViewProgrammeViewModel ViewProgrammeViewModel { get; } = new ViewProgrammeViewModel(App.ProgrammeDataStore, App.NavigationService);
        public static DeleteProgrammeViewModel DeleteProgrammeViewModel { get; } = new DeleteProgrammeViewModel(App.NavigationService, App.ProgrammeDataStore);
    }
}
