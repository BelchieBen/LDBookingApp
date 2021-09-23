using LDBookingApp.Utility;
using Xamarin.Forms.Xaml;

namespace LDBookingApp.Views.Programmes
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DeleteProgramme
    {
        public DeleteProgramme()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.DeleteProgrammeViewModel;
        }
    }
}