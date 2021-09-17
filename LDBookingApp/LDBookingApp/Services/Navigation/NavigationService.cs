using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using LDBookingApp.ViewModels;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Contracts;
using System.Runtime.InteropServices;
using LDBookingApp.Models;

namespace LDBookingApp.Services.Navigation
{
    public class NavigationService: INavigationService
    {
        private IPopupNavigation _popupNavigation;
        private Dictionary<string, Type> pages { get; } = new Dictionary<string, Type>();

        public NavigationService(IPopupNavigation popupNavigation)
        {
            _popupNavigation = popupNavigation;
        }

        public Page MainPage => Application.Current.MainPage;

        public void Configure(string key, Type pageType) => pages[key] = pageType;

        public void GoBack() => MainPage.Navigation.PopAsync();

        public async Task GoTo(string pageKey)
        {
            if (pages.TryGetValue(pageKey, out Type pageType))
            {
                var page = (Page)Activator.CreateInstance(pageType);
                await MainPage.Navigation.PushAsync(page);
            }
        }

        public async Task NavigateTo(string pageKey, object parameter = null)
        {
            if (pages.TryGetValue(pageKey, out Type pageType))
            {
                var page = (Page)Activator.CreateInstance(pageType);
                page.SetNavigationArgs(parameter);
                await MainPage.Navigation.PushAsync(page);
                (page.BindingContext as BaseViewModel).Initialize(parameter);
            }
            else
            {
                throw new ArgumentException($"This page doesn't exist: {pageKey}.", nameof(pageKey));
            }
        }

        public void NavigteAsync(string key)
        {
            
        }

        public async Task PushPopUp(string pageKey, object parameter = null)
        {
            if (pages.TryGetValue(pageKey, out Type pageType))
            {
                var page = (Page)Activator.CreateInstance(pageType);
                page.SetNavigationArgs(parameter);
                await _popupNavigation.PushAsync((PopupPage)page);
                (page.BindingContext as BaseViewModel).Initialize(parameter);
            }
        }

        public async Task RemovePopUp()
        {
            await _popupNavigation.PopAsync();
        }

        public async Task RemoveAllPopup()
        {
            await _popupNavigation.PopAllAsync();
        }

        public async void PopPage()
        {
            await Application.Current.MainPage.Navigation.PopAsync();
        }
    }

    public static class NavigationExtensions
    {
        private static ConditionalWeakTable<Page, object> arguments = new ConditionalWeakTable<Page, object>();

        public static object GetNavigationArgs(this Page page)
        {
            object argument;
            arguments.TryGetValue(page, out argument);

            return argument;
        }

        public static void SetNavigationArgs(this Page page, object args)
            => arguments.Add(page, args);
    }
}
