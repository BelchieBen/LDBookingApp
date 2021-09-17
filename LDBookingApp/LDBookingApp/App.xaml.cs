using LDBookingApp.Services.Courses;
using LDBookingApp.Services.Dialogs;
using LDBookingApp.Services.Navigation;
using LDBookingApp.Utility;
using LDBookingApp.Views;
using LDBookingApp.Views.Courses;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace LDBookingApp
{
    public partial class App : Application
    {
        public static CourseDataService CourseDataService { get; } = new CourseDataService();
        public static DialogService DialogService { get; } = new DialogService();
        public static NavigationService NavigationService { get; } = new NavigationService(PopupNavigation.Instance);
        public App()
        {
            InitializeComponent();

            NavigationService.Configure(ViewNames.AddCourse, typeof(AddCourse));
            NavigationService.Configure(ViewNames.ViewCourse, typeof(ViewCourse));
            NavigationService.Configure(ViewNames.ViewAllCourses, typeof(CoursesViewAllPage));
            NavigationService.Configure(ViewNames.DeleteCourse, typeof(DeleteCourse));
            NavigationService.Configure(ViewNames.Homepage, typeof(Homepage));

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
