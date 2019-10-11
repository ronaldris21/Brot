using BrotCliente.Class;
using DLL.ResponseModels;
using DLL.Service;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;

namespace BrotCliente.ViewModels
{
    public class PostViewModel : BaseViewModel
    {
        public ObservableCollection<string> lista { get; }
        private ObservableCollection<ResponseComentarios> _comentariosData;
        private ResponsePublicacion _Post;
        public int idPost { get; set; }
        public ObservableCollection<ResponseComentarios> ComentariosData
        {
            get { return _comentariosData; }
            set
            {
                if (_comentariosData!=value)
                {
                    _comentariosData = value;
                    OnPropertyChanged("ComentariosData");
                }
            }
        }
        public ResponsePublicacion Post
        {
            get { return _Post; }
            set
            {
                _Post = value;
                OnPropertyChanged("Post");
            }
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
                ResponsePublicacion publicacionData = await RestAPI.Getpublicacion(this.idPost, Singleton.Usuario.usuario.id_user);
                if (publicacionData == null)
                {
                    Dialogos.ToastBAD("No es posible cargas los comentarios, revise su internet o intente de nuevo", 2500);
                }
                else
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

        /// DATOS ESTATICOS DE PRUEBA

        //public PostViewModel()
        //{
        //    this.lista = new ObservableCollection<string>();
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //    this.lista.Add("asdfaksjdfhasjdkfhajdsfhakdjhfajksdfhajdhfjkasdhfjaksdhf");
        //}


        //public PostViewModel(ResponsePublicacionFeed item)
        //{
        //    this.Post = item;
        //}
    }
}
