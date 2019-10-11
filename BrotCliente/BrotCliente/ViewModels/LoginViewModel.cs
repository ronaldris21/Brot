using BrotCliente.Views;
using BrotCliente.Class;
using DLL.Models;
using DLL.Service;
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

        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(loginMethod);
            }
        }

        #region Commands

        public void RegisterUser()
        {
            Application.Current.MainPage.Navigation.PushAsync(new Signup());
        }

        public async void loginMethod()
        {
            userModel userReceived = await RestAPI.login(Passs, usuarioText);
            if (userReceived!=null)
            {
                Dialogos.ToastOk("Bienvenido " + userReceived.nombre, 4000);
                Singleton.Usuario = new UserLogged()
                {
                    Rememberme = SwitchMantenerSesion,
                    usuario = userReceived
                };
                Singleton.current.Json.SaveData(Singleton.Usuario);
                Application.Current.MainPage = new NavigationPage(new Master());
            }
            Dialogos.ToastBAD("Credenciales incorrectas",1500);
        }

        private string _usuarioText;
        public string usuarioText
        {
            get { return _usuarioText; }
            set
            {
                if(_usuarioText != value)
                {
                    _usuarioText = value;
                    OnPropertyChanged("usuarioText");
                }
            }
        }

        private string _passs;
        public string Passs
        {
            get { return _passs; }
            set
            {
                if(_passs != value)
                {
                    _passs = value;
                    OnPropertyChanged("Passs");
                }
            }
        }

        private bool _SwitchMantenerSesion;
        public bool SwitchMantenerSesion
        {
            get { return _SwitchMantenerSesion; }
            set
            {
                if(_SwitchMantenerSesion != value)
                {
                    _SwitchMantenerSesion = value;
                    OnPropertyChanged("SwitchMantenerSesion");
                }
            }
        }

        #endregion
    }
}
