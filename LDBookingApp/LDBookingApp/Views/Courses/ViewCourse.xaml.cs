using LDBookingApp.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LDBookingApp.Views.Courses
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ViewCourse
    {
        public ViewCourse()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.ViewCourseViewModel;
        }
    }
}