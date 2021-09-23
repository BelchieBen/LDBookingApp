using LDBookingApp.Utility;
using Xamarin.Forms.Xaml;

namespace LDBookingApp.Views.Programmes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProgramme
    {
        public AddProgramme()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.AddProgrammeViewModel;
        }
    }
}