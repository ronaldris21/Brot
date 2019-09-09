using GalaSoft.MvvmLight.Command;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BrotCliente.ViewModels
{
    class ChangeNameViewModel : BaseViewModel
    {
        public ICommand CancelCommand
        {
            get
            {
                return new RelayCommand(Cancel);
            }
        }

        private async void Cancel()
        {
            await PopupNavigation.PopAsync();
        }
    }
}
