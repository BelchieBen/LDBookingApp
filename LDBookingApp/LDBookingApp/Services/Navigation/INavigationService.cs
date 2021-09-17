using LDBookingApp.Models;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LDBookingApp.Services.Navigation
{
    public interface INavigationService
    {
        Page MainPage { get; }

        void Configure(string key, Type pageType);
        void GoBack();
        Task GoTo(string key);
        Task NavigateTo(string key, object parameter = null);
        void NavigteAsync(string key);
        void PopPage();
        Task PushPopUp(string addCourse, object parameter = null);
        Task RemovePopUp();
        Task RemoveAllPopup();
    }
}
