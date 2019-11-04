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
    public class MyLoginViewModel:BaseViewModel
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
                _usuario = value; OnPropertyChanged("usuario");
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
                _clave = value; OnPropertyChanged("clave");
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
                _remember = value; OnPropertyChanged("remember");
            }
        }
        #endregion
        #region Constructor
        public MyLoginViewModel()
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
            Usuario u = new Usuario();
            u.username = usuario;
            u.pass = clave;
            Response result = await api.Post<Usuario>("users/login", u);
            if (!result.isSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", result.Message, "Aceptar");
                return;
            }
            u = (Usuario)result.Result;
            if (remember)
            {
                u.RememberMe = true;
            }
            else
            {
                u.RememberMe = false;
            }
            Singleton.current.Json.SaveData(u);
            Singleton.current.user = u;
            App.Current.MainPage = new NavigationPage(new Inicio());
        }
        #endregion
    }
}
