
namespace Brot.Services
{
    using Acr.UserDialogs;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Essentials;

    public class DialogService
    {
        public async Task Message(string title, string message)
        {
            await App.Current.MainPage.DisplayAlert(title, message, "Ok");
        }

        public async Task<bool> Message(string title, string message, string ok, string cancel)
        {
            return await App.Current.MainPage.DisplayAlert(title, message, ok,cancel);
        }

    }
}
