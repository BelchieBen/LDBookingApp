using System;
using System.Threading.Tasks;
using Acr.UserDialogs;
using Xamarin.Forms;

namespace LDBookingApp.Services.Dialogs
{
    public class DialogService: IDialogService
    {
        public Task ShowDialogAsync(string message, string title, string button)
        {
            return UserDialogs.Instance.AlertAsync(message, title, button);
        }
        public void ShowToastMessage(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                UserDialogs.Instance.Toast(new ToastConfig(message)
                    .SetDuration(TimeSpan.FromMilliseconds(1500))
                    .SetPosition(ToastPosition.Bottom)
                    .SetBackgroundColor(Color.White)
                    .SetMessageTextColor(Color.FromHex("#1a3d54")));
            });
        }
    }
}
