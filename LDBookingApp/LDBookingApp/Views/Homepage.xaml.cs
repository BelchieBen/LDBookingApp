using LDBookingApp.Utility;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LDBookingApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Homepage : ContentPage
    {
        public Homepage()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.HomepageViewModel;
        }
    }
}