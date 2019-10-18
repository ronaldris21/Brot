using BrotCliente.Patterns;
using BrotCliente.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BrotCliente.ViewModels
{
    public class ProfileViewModel : BaseViewModel
    {
        #region Attributes

        public ICommand EditProfileCommand
        {
            get { return new RelayCommand(EditProfile); }
        }
        public ICommand SignOutCommand { get { return new RelayCommand(Signout); } }

      

        #endregion

        #region Methods

        private void EditProfile()
        {
            Application.Current.MainPage.Navigation.PushAsync(new EditProfile());
        }
        private void Signout()
        {
            Singleton.Instance.LocalJson.SignOut();
            App.Current.MainPage = new NavigationPage(new Login());
        }


        #endregion
    }
}
