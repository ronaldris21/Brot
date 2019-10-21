using Android.Widget;
using DLL.Models;
using BrotCliente.Patterns;
using BrotCliente.Services;
using BrotCliente.Views;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace BrotCliente.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Attributes

        private string _Username;
        private string _Password;
        private bool _Remember;

        #endregion

        #region Properties

        public string Username
        {
            get { return this._Username; }
            set
            {
                if (this._Username == value)
                    return;

                this._Username = value;
                OnPropertyChanged();
            }
        }

        public string Password
        {
            get { return this._Password; }
            set
            {
                if (this._Password == value)
                    return;

                this._Password = value;
                OnPropertyChanged();
            }
        }

        public bool Remember
        {
            get { return this._Remember; }
            set
            {
                if (this._Remember == value)
                    return;

                this._Remember = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand SignupCommand
        {
            get
            {
                return new RelayCommand(RegisterUser);
            }
        }

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        #endregion

        #region Methods

        private void RegisterUser()
        {
            Application.Current.MainPage.Navigation.PushAsync(new Signup());
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Username) || string.IsNullOrEmpty(this.Password))
            {
                await Singleton.Instance.Dialogs.Message("Error", "You must fill all fields");
                return;
            }

            var result = await RestClient.Post<userModel>("users/login", new userModel()
            {
                username = this.Username,
                pass = this.Password
            });

            if (result.IsSuccess)
            {
                Singleton.Instance.User = (userModel)result.Result;

                //if (this.Remember)
                    Singleton.Instance.LocalJson.SaveData((userModel) result.Result);

                Toast.MakeText(Android.App.Application.Context, $"Bienvenido {Singleton.Instance.User.username}", ToastLength.Short).Show();
                Application.Current.MainPage = new NavigationPage(new Master());
            }
            else
            {
                await Singleton.Instance.Dialogs.Message("Server connection error", result.Message);
            }
        }

        #endregion
    }
}
