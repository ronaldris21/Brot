using BrotApi0.Models;
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
        #endregion
        #region Constructor
        public LoginViewModel()
        {

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
        public void GoToMain()
        {
            //check the user and pass
            users u = new users();
            u.username = usuario;
            u.pass = clave;
            String result = Newtonsoft.Json.JsonConvert.SerializeObject(u);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string filePath = Path.Combine(path, "user.txt");
            using (var file = File.Open(filePath, FileMode.Create, FileAccess.Write))
            using (var strm = new StreamWriter(file))
            {
                strm.Write(result);
            }
            App.Current.MainPage = new NavigationPage(new Inicio());
        }
        #endregion
    }
}
