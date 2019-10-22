using DLL.Models;
using BrotVendedor.Class;
using BrotVendedor.Model;
using BrotVendedor.View;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace BrotVendedor.ViewModel
{
    public class LoginViewModel:BaseViewModel
    {
        #region Atributos
        private String _usuario;
        private String _clave;
        private bool _remember;
        private ApiService api;
        #endregion
        #region Propiedades
        public String usuario
        {
            get
            {
                return _usuario;
            }
            set
            {
                _usuario = value;OnPropertyChanged("usuario");
            }
        }
        public String clave
        {
            get
            {
                return _clave;
            }
            set
            {
                _clave = value;OnPropertyChanged("clave");
            }
        }
        public bool remember
        {
            get
            {
                return _remember;
            }
            set
            {
                _remember = value;OnPropertyChanged("remember");
            }
        }
        #endregion
        #region Constructor
        public LoginViewModel()
        {
            remember = false;
            api = new ApiService();
        }
        #endregion
        #region Comandos
        public ICommand Registro
        {
            get
            {
                return new RelayCommand(GoToRegister);
            }
        }
        public ICommand Login
        {
            get
            {
                return new RelayCommand(GoToMain);
            }
        }
        #endregion
        #region Metodos
        public void GoToRegister()
        {
            App.Current.MainPage.Navigation.PushAsync(new Register());
        }
        public async void GoToMain()
        {
            //check the user and pass
            if (String.IsNullOrEmpty(usuario) || String.IsNullOrEmpty(clave))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Uno o mas campos estan vacios", "Aceptar");
            }
            userModel u = new userModel();
            u.username = usuario;
            u.pass = clave;
            Response result = await api.Post<userModel>("users/login", u);
            if (!result.isSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error",result.Message,"Aceptar");
                return;
            }
            u = (userModel)result.Result;
            if (u.isVendor)
            {
                Singleton.current.Json.SaveData(u);
                Singleton.current.user = u;
                App.Current.MainPage = new NavigationPage(new Inicio());
            }
            else
            {
                await App.Current.MainPage.DisplayAlert("Error", "Su cuenta no es de un vendedor, por favor inicie sesión como un usuario de tipo vendedor o registre una nueva cuenta", "Aceptar");
            }
        }
        #endregion
    }
}
