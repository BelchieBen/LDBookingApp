﻿using LDBookingApp.Utility;
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
    public partial class AddCourse
    {
        public AddCourse()
        {
            InitializeComponent();
            BindingContext = ViewModelLocator.AddCourseViewModel;
        }
    }
}