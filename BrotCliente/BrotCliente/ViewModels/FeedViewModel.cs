using BrotApi0.Models;
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
    public class FeedViewModel : BaseViewModel
    {
        #region Attributes

        private ObservableCollection<ResponsePublicacionFeed> _lPosts;

        #endregion

        #region Properties

        public ObservableCollection<ResponsePublicacionFeed> lPosts
        {
            get { return this._lPosts; }
            set
            {
                if (this._lPosts == value)
                    return;

                this._lPosts = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructor

        public FeedViewModel()
        {
            this.lPosts = new ObservableCollection<ResponsePublicacionFeed>();
            LoadFeed();
        }

        #endregion

        #region Commands

        public ICommand RefreshCommand
        {
            get { return new RelayCommand(Refresh); }
        }

        public ICommand LikeCommand
        {
            get
            {
                return new RelayCommand<int>(Like);
            }
        }

        #endregion

        #region Methods

        public async void Refresh()
        {
            if (IsRefreshing)
                return;

            IsRefreshing = true;

            try
            {
                await App.Current.MainPage.DisplayAlert("Refresh", "Refreshing", "ok");
            }
            catch (Exception)
            {
                Debug.WriteLine("Is Busy");
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        private async void Like(int idLike)
        {
            await App.Current.MainPage.DisplayAlert("EXITO", "Has presionado el boton " + idLike, "Ok");
        }

        //SOLO PRUBEA
        //BORRAR CUANDO FUNCIONE EL API
        public async void LoadFeed()
        {
            var result = await RestClient.GetAll<ResponsePublicacionFeed>($"publicaciones/all/{Singleton.Instance.User.id_user}/");

            if (!result.IsSuccess)
            {
                await Singleton.Instance.Dialogs.Message("There was a problem trying to get the feed", result.Message);
                return;
            }

            foreach (var post in (ObservableCollection<ResponsePublicacionFeed>) result.Result)
            {
                post.publicacion.img = $"http://images.somee.com/Uploads/{post.publicacion.img}";
                this.lPosts.Add(post);
            }

            ResponsePublicacionFeed p1 = new ResponsePublicacionFeed()
            {
                UsuarioCreator = new userModel()
                {
                    username = "Mario"
                },
                publicacion = new publicacionesModel()
                {
                    fecha_creacion = DateTime.Now,
                    img = "https://py-softwaresv.com/wp-content/uploads/2019/08/Logo_Square_512-300x300.png",
                    isImg = true
                }
            };

            this.lPosts.Add(p1);

            //ResponsePublicacionFeed p2 = new ResponsePublicacionFeed()
            //{
            //    id_post = 2,
            //    descripcion = "Este es un post de prueba sin imagen",
            //    fecha_actualizacion = DateTime.Now,
            //    fecha_creacion = DateTime.Now,
            //    id_user = 2,
            //    img = null,
            //    isimg = false
            //};

            //ResponsePublicacionFeed p3 = new ResponsePublicacionFeed()
            //{
            //    id_post = 3,
            //    descripcion = "Este es otro post de prueba con imagen",
            //    fecha_actualizacion = DateTime.Now,
            //    fecha_creacion = DateTime.Now,
            //    id_user = 1,
            //    img = "https://py-softwaresv.com/wp-content/uploads/2019/08/Logo_Square_512-300x300.png",
            //    isimg = true
            //};

            //ResponsePublicacionFeed p4 = new ResponsePublicacionFeed()
            //{
            //    id_post = 4,
            //    descripcion = "Este es otro post de prueba sin imagen",
            //    fecha_actualizacion = DateTime.Now,
            //    fecha_creacion = DateTime.Now,
            //    id_user = 2,
            //    img = null,
            //    isimg = false
            //};

            //this.lPosts.Add(p1);
            //this.lPosts.Add(p2);
            //this.lPosts.Add(p3);
            //this.lPosts.Add(p4);
        }

        #endregion
    }
}
