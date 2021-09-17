using System.Threading.Tasks;

namespace LDBookingApp.Services.Dialogs
{
    public interface IDialogService
    {
        Task ShowDialogAsync(string message, string title, string button);
        void ShowToastMessage(string message);
    }
}
