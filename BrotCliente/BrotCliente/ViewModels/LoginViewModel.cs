using BrotCliente.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BrotCliente.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand SignupCommand
        {
            get
            {
                return new RelayCommand(RegisterUser);
            }
        }

        public ICommand GoToMainCommand
        {
            get
            {
                return new RelayCommand(GoToMainPage);
            }
        }

        #region Commands

        public void RegisterUser()
        {
            Application.Current.MainPage.Navigation.PushAsync(new Signup());
        }

        public void GoToMainPage()
        {
            Application.Current.MainPage = new NavigationPage(new MainTabbed());
        }

        #endregion
    }
}
