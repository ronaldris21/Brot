using BrotCliente.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BrotCliente.ViewModels
{
    public class SignupViewModel : BaseViewModel
    {
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(LoginUser);
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

        public void LoginUser()
        {
            Application.Current.MainPage.Navigation.PopAsync();
        }

        public void GoToMainPage()
        {
            Application.Current.MainPage = new NavigationPage(new Master());
        }

        #endregion
    }
}
