﻿namespace BrotVendedor.ViewModel
{
    using BrotApi0.Models;
    using BrotVendedor.Class;
    using BrotVendedor.Model;
    using BrotVendedor.View.Tabs.Buttons;
    using GalaSoft.MvvmLight.Command;
    using Plugin.Media;
    using Plugin.Media.Abstractions;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.Net.Http;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class ProfileViewModel : BaseViewModel
    {
        #region Atributos
        private ApiService api;
        private String _usuario;
        private String _nombre;
        private String _apellido;
        private String _correo;
        private String _telefono;
        private String _dui;
        private String _clave;
        private ImageSource _picture;
        private Usuario u;  
        private bool modificado = false;
        private bool clicked;
        private bool firstTime;
        private string im;
        #endregion
        #region Propiedades
        public String img
        {
            get
            {
                return im;
            }
            set
            {
                im = value; OnPropertyChanged("img");
            }
        }
        public bool Modificado
        {
            get
            {
                return modificado;
            }
            set
            {
                modificado = value; OnPropertyChanged("Modificado");
            }
        }
        public String usuario
        {
            get
            {
                return _usuario;
            }
            set
            {
                _usuario = value; OnPropertyChanged("usuario");
                if (clicked)
                {
                    modificado = true;
                    img = "save.png";
                }
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
                _nombre = value; OnPropertyChanged("nombre");
                if (clicked)
                {
                    modificado = true;
                    img = "save.png";
                }
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
                _apellido = value; OnPropertyChanged("apellido");
                if (clicked)
                {
                    modificado = true;
                    img = "save.png";
                }
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
                _correo = value; OnPropertyChanged("correo");
                if (clicked)
                {
                    modificado = true;
                    img = "save.png";
                }
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
                _telefono = value; OnPropertyChanged("telefono");
                if (clicked)
                {
                    modificado = true;
                    img = "save.png";
                }
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
                _dui = value; OnPropertyChanged("dui");
                if (clicked)
                {
                    modificado = true;
                    img = "save.png";
                }
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
                if (clicked)
                {
                    modificado = true;
                    img = "save.png";
                }
            }
        }
        public ImageSource picture
        {
            get
            {
                return _picture;
            }
            set
            {
                _picture = value; OnPropertyChanged("picture");
                if (clicked)
                {
                    modificado = true;
                    img = "save.png";
                }
            }
        }
        #endregion
        #region Constructor
        public ProfileViewModel()
        {
            img = "";
            firstTime = true;
            api = new ApiService();
            modificado = false;
            u = Class.Singleton.current.Json.ReadData();
            usuario = u.username;
            clave = u.pass;
            nombre = u.nombre;
            apellido = u.apellido;
            correo = u.email;
            dui = u.dui;
            telefono = u.num_telefono;
            picture = "http://images.somee.com/Uploads/" + u.img;
            firstTime = false;
        }
        #endregion
        #region Commands
        public ICommand ChangeProfilePicture
        {
            get
            {
                return new RelayCommand(Singleton.current.ChangePic);
            }
        }
        public ICommand UpdateData
        {
            get
            {
                return new RelayCommand(updateInfo);
            }
        }
        public ICommand click
        {
            get
            {
                return new RelayCommand(clickeado);
            }
        }
        #endregion
        #region Metodos
        private void clickeado()
        {
            clicked = true;
        }
        private async void updateInfo()
        {
            if (modificado && clicked)
            {
                Singleton.current.user.nombre = nombre;
                Singleton.current.user.username = usuario;
                Singleton.current.user.apellido = apellido;
                Singleton.current.user.pass = clave;
                Singleton.current.user.email = correo;
                Singleton.current.user.num_telefono = telefono;
                Singleton.current.user.dui = dui;
                Response resp = await api.Put<Usuario>("users", Singleton.current.user.id_user, Singleton.current.user);
                if (!resp.isSuccess)
                {
                    await App.Current.MainPage.DisplayAlert("Error", resp.Message, "Aceptar");
                    return;
                }
                await App.Current.MainPage.DisplayAlert("Exito", "La informacion ha sido actualizada con exito", "Aceptar");
                return;
            }
            //await App.Current.MainPage.DisplayAlert("Error", "No hay informacion para actualizar", "Aceptar");

        }
        #endregion
    }
}