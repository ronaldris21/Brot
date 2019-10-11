using BrotCliente.Class;
using BrotCliente.Views;
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
    public class SignupViewModel : BaseViewModel
    {
        public ICommand BackLoginCommand
        {
            get
            {
                return new RelayCommand(LoginUser);
            }
        }

        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(RegisterMethod);
            }
        }


        #region Commands

        public void LoginUser()
        {
            Application.Current.MainPage = new NavigationPage(new Login());
        }

        public async void RegisterMethod()
        {
            if (Usuario.pass==passConfirmation)
            {
                if (! await RestAPI.validandoUsername(Usuario.username))
                {
                    Dialogos.ToastBAD("Ya existe el nombre de usuario elegido", 2000);
                    return;
                }
                if (await RestAPI.Post<userModel>(Usuario,TableName.userst))
                {
                    Dialogos.ToastOk("Acabas de registrarte exitosamente, ahora debes de iniciar sesión", 2000);
                    Application.Current.MainPage = new NavigationPage(new Master());
                }
            }
        }

        private userModel _usuario;
        public userModel Usuario
        {
            get { return _usuario; }
            set
            {
                if(_usuario != value)
                {
                    _usuario = value;
                    OnPropertyChanged("Usuario");
                }
            }
        }

        private string _passConfirmation;
        public string passConfirmation
        {
            get { return _passConfirmation; }
            set
            {
                if(_passConfirmation != value)
                {
                    _passConfirmation = value;
                    OnPropertyChanged("passConfirmation");
                }
            }
        }

        #endregion
    }
}
