using BrotCliente.Patterns;
using BrotCliente.Views;
using BrotCliente.Views.Popups;
using GalaSoft.MvvmLight.Command;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BrotCliente.ViewModels
{
    public class MenuItemsViewModel : BaseViewModel
    {
        #region Commands

        public ICommand SignoutCommand
        {
            get
            {
                return new RelayCommand(Signout);
            }
        }
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

        #endregion

        #region Constructor


        #endregion

        #region Methods

        private void Signout()
        {
            if (Singleton.Instance.LocalJson.IsUserLogged())
                Singleton.Instance.SignOut();

            Singleton.Instance.User = null;
            Application.Current.MainPage = new NavigationPage(new Login());
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

        #endregion
    }
}
