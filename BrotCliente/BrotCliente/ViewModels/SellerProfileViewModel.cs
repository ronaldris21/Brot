using BrotCliente.Patterns;
using BrotCliente.Services;
using BrotCliente.Views;
using DLL.ResponseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BrotCliente.ViewModels
{
    public class SellerProfileViewModel : BaseViewModel
    {
        private ResponseUserProfile _Usuario;
        private int idProfileHere;
        private ResponsePublicacionFeed _publicacionesThis;

        public ResponsePublicacionFeed publicacionesThis
        {
            get { return _publicacionesThis; }
            set
            {
                if (this._publicacionesThis==value)
                {
                    return;
                }
                this._publicacionesThis = value;

                App.Current.MainPage.Navigation.PushAsync(new Post(new PostViewModel(_publicacionesThis)));

                this._publicacionesThis = null;
                OnPropertyChanged("_publicacionesThis");
            }
        }
        public ResponseUserProfile Usuario
        {
            get { return this._Usuario; }
            set
            {
                if (this._Usuario == value)
                    return;

                this._Usuario = value;
                OnPropertyChanged();
            }
        }

        public SellerProfileViewModel(ResponseUserProfile item)
        {
            _Usuario = new ResponseUserProfile();

            this.Usuario.UserProfile.id_user = item.UserProfile.id_user;
            this.Usuario.UserProfile.username = item.UserProfile.username;
            this.Usuario.UserProfile.descripcion = item.UserProfile.descripcion;
            this.Usuario.UserProfile.puesto_name = item.UserProfile.puesto_name;
            this.Usuario.UserProfile.img = item.UserProfile.img;
        }

        public SellerProfileViewModel(int idProfile)
        {
            idProfileHere = idProfile;
            Usuario = new ResponseUserProfile();
            CargarDatos();
        }

        public async void CargarDatos()
        {

            ResponseUserProfile profiledata = await RestAPI.GetOtherUserrofile(idProfileHere, Singleton.Instance.User.id_user);

            if (profiledata!= null)
            {
                Usuario = profiledata;
                Usuario.UserProfile.img = DLL.constantes.urlImages + profiledata.UserProfile.img;
                for (int i = 0; i < Usuario.publicacionesUser.Count; i++)
                {
                    Usuario.publicacionesUser[i].UsuarioCreator = Usuario.UserProfile;
                    Usuario.publicacionesUser[i].publicacion.img = DLL.constantes.urlImages+ Usuario.publicacionesUser[i].publicacion.img;
                }
            }

        }

    }
}
