using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BrotCliente.Services
{
    public class DialogService
    {
        public async Task Message(string title, string message)
        {
            await App.Current.MainPage.DisplayAlert(title, message, "Accept");
        }

        public async Task<bool> Message(string title, string message, string ok, string cancel)
        {
            return await App.Current.MainPage.DisplayAlert(title, message, ok, cancel);
        }
    }
}
