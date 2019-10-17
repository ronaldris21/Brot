using BrotCliente.Patterns;
using BrotCliente.Services;
using DLL.ResponseModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace BrotCliente.ViewModels
{
    public class PostViewModel :  GalaSoft.MvvmLight.ViewModelBase
    {
        private ObservableCollection<ResponseComentarios> _comentariosData;
        private ResponsePublicacion _Post;
        public int idPost { get; set; }
        public ObservableCollection<ResponseComentarios> ComentariosData
        {
            get { return _comentariosData; }
            set
            {
                Set(ref _comentariosData, value);
                //if (_comentariosData != value)
                //{
                //    _comentariosData = value;
                //    //OnPropertyChanged("ComentariosData");
                //}
            }
        }
        public bool IsRefreshing;
        public ResponsePublicacion Post
        {
            get { return _Post; }
            set { Set(ref _Post, value); }                
        }

        public PostViewModel(ResponsePublicacionFeed postFeed)
        {
            this.idPost = postFeed.publicacion.id_post;
            Post = new ResponsePublicacion();
            ComentariosData = new ObservableCollection<ResponseComentarios>();
            //Esto lo hago para que ya tenga los datos del Feed mientras están cargando los demás datos como comentarios
            Post.publicacion = postFeed;
            Post.comentarios = new List<ResponseComentarios>();
            CargarDatos();
        }

        private async void CargarDatos()
        {
            if (IsRefreshing)
                return;

            IsRefreshing = true;
            try
            {
                var prueba = await RestAPI.GetPublicacionesALL(Post.publicacion.UsuarioCreator.id_user);
                Debug.Print(prueba.ToString());

                ResponsePublicacion publicacionData = await RestAPI.Getpublicacion(this.idPost, Singleton.Instance.User.id_user);
                if (publicacionData != null)
                {
                    Post = publicacionData;
                    if (Post.comentarios.Count > 0)
                    {
                        //Siempre validar cuando instanciamos un Observable Collection porque por default es null
                        //ObservableCollection<ResponseComentarios>(null)    DA ERROR!!
                        ComentariosData = new ObservableCollection<ResponseComentarios>(Post.comentarios);
                    }
                }

            }
            catch (Exception e)
            {
                Debug.Print($"Error en postViewmodel  --{e.Message}");
            }
            finally
            {
                IsRefreshing = false;
            }
        }


        public ICommand RefreshCommand
        {
            get { return new RelayCommand(CargarDatos); }
        }

    }
}
