using BrotCliente.Views.Popups;
using GalaSoft.MvvmLight.Command;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace BrotCliente.ViewModels
{
    class MenuItemsViewModel
    {
        public ICommand ChangeNameCommand
        {
            get
            {
                return new RelayCommand(ChangeName);
            }
        }
        public ICommand ChangeLastnameCommand
        {
            get
            {
                return new RelayCommand(ChangeLastname);
            }
        }
        public ICommand ChangeDescriptionCommand
        {
            get
            {
                return new RelayCommand(ChangeDescription);
            }
        }

        private async void ChangeDescription()
        {
            await PopupNavigation.PushAsync(new ChangeDescription());
        }

        private async void ChangeLastname()
        {
            await PopupNavigation.PushAsync(new ChangeLastname());
        }

        private async void ChangeName()
        {
            await PopupNavigation.PushAsync(new ChangeName());
        }
    }
}
