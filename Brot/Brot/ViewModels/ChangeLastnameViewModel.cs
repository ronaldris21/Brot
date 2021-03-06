﻿

namespace Brot.ViewModels
{
    using Rg.Plugins.Popup.Services;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Windows.Input;
    public class ChangeLastnameViewModel : BaseViewModel
    {
        public ICommand CancelCommand
        {
            get
            {
                return new Xamarin.Forms.Command(Cancel);
            }
        }

        private async void Cancel()
        {
            await PopupNavigation.PopAsync();
        }
    }
}
