using LDBookingApp.Data.Courses;
using LDBookingApp.Data.Programmes;
using LDBookingApp.DatabaseContext;
using LDBookingApp.Services.Courses;
using LDBookingApp.Services.Dialogs;
using LDBookingApp.Services.Navigation;
using LDBookingApp.Services.Programmes;
using LDBookingApp.Utility;
using LDBookingApp.Views;
using LDBookingApp.Views.Courses;
using LDBookingApp.Views.Programmes;
using Microsoft.EntityFrameworkCore;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace LDBookingApp
{
    public partial class App : Application
    {
        public static CourseDataService CourseDataService { get; } = new CourseDataService();
        public static DialogService DialogService { get; } = new DialogService();
        public static ProgrammeDataService ProgrammeDataService { get; } = new ProgrammeDataService();
        public static NavigationService NavigationService { get; } = new NavigationService(PopupNavigation.Instance);
        public static CourseDataStore CourseDataStore;
        public static ProgrammeDataStore ProgrammeDataStore;
        public static ApplicationDbContext ApplicationDbContext;
        public App(string databasePath)
        {
            InitializeComponent();

            // General Actions
            NavigationService.Configure(ViewNames.DeleteCourse, typeof(DeleteCourse));
            NavigationService.Configure(ViewNames.Homepage, typeof(Homepage));

            // Course Actions
            NavigationService.Configure(ViewNames.AddCourse, typeof(AddCourse));
            NavigationService.Configure(ViewNames.ViewCourse, typeof(ViewCourse));
            NavigationService.Configure(ViewNames.ViewAllCourses, typeof(CoursesViewAllPage));

            // Programme Actions
            NavigationService.Configure(ViewNames.AddProgramme, typeof(AddProgramme));
            NavigationService.Configure(ViewNames.ViewProgramme, typeof(ViewProgramme));
            NavigationService.Configure(ViewNames.ViewAllProgramme, typeof(ProgrammeViewAllPage));
            NavigationService.Configure(ViewNames.DeleteProgramme, typeof(DeleteProgramme));

            ApplicationDbContext = new ApplicationDbContext(databasePath);
            CourseDataStore = new CourseDataStore(databasePath);
            ProgrammeDataStore = new ProgrammeDataStore(databasePath);

            
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
