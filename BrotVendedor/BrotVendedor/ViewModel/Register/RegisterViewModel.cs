using BrotVendedor.Model;
using BrotVendedor.View;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace BrotVendedor.ViewModel
{
    public class RegisterViewModel:BaseViewModel
    {
        #region Atributos
        private String _usuario;
        private String _nombre;
        private String _apellido;
        private String _clave;
        private String _correo;
        private String _telefono;
        private String _dui;
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
        public String nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;OnPropertyChanged("nombre");
            }
        }
        public String apellido
        {
            get
            {
                return _apellido;
            }
            set
            {
                _apellido = value;OnPropertyChanged("apellido");
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
        public String correo
        {
            get
            {
                return _correo;
            }
            set
            {
                _correo = value;OnPropertyChanged("correo");
            }
        }
        public String telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;OnPropertyChanged("telefono");
            }
        }
        public String dui
        {
            get
            {
                return _dui;
            }
            set
            {
                _dui = value;OnPropertyChanged("dui");
            }
        }
        #endregion
        #region Constructor
        public RegisterViewModel()
        {

        }
        #endregion
        #region Comandos
        public ICommand Siguiente
        {
            get
            {
                return new RelayCommand(ChooseLocation);
            }
        }
        public ICommand Cancel
        {
            get
            {
                return new RelayCommand(Dispose);
            }
        }
        #endregion
        #region Metodos
        public void ChooseLocation()
        {
            if (!CheckAll())
            {
                App.Current.MainPage.DisplayAlert("Error", "Uno o mas campos estan vacios", "Aceptar");
            }
            Usuario user = new Usuario
            {
                username = usuario,
                nombre = nombre,
                apellido = apellido,
                pass = clave,
                email = correo,
                num_telefono = telefono,
                dui = dui,
                isVendor = true,
                isActive=true,
                isDeleted=false
            };
            App.Current.MainPage.Navigation.PushAsync(new ChooseLocation(user, "Registrar"));

        }
        public void Dispose()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
        public bool CheckAll()
        {
            if (String.IsNullOrEmpty(usuario))
            {
                return false;
            }
            if (String.IsNullOrEmpty(nombre))
            {
                return false;
            }
            if (String.IsNullOrEmpty(apellido))
            {
                return false;
            }
            if (String.IsNullOrEmpty(clave))
            {
                return false;
            }
            if (String.IsNullOrEmpty(correo))
            {
                return false;
            }
            if (String.IsNullOrEmpty(telefono))
            {
                return false;
            }
            if (String.IsNullOrEmpty(dui))
            {
                return false;
            }
            return true;
        }
        #endregion
    }
}
