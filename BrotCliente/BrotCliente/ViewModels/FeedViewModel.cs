using DLL.Models;
using DLL.ResponseModels;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using DLL.Service;
using BrotCliente.Class;

namespace BrotCliente.ViewModels
{
    public class FeedViewModel : BaseViewModel
    {
        private ObservableCollection<ResponsePublicacionFeed> _lPosts;
        public ObservableCollection<ResponsePublicacionFeed> lPosts
        {
            get { return this._lPosts; }
            set
            {
                if (this._lPosts == value)
                    return;

                this._lPosts = value;
                OnPropertyChanged("lPosts");
            }
        }

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

        public FeedViewModel()
        {
            this.lPosts = new ObservableCollection<ResponsePublicacionFeed>();
            //cargarImgs();//Borraar luego
            IsRefreshing = false;
            Refresh();
        }

        public async void Refresh()
        {
            if (IsRefreshing)
                return;

            IsRefreshing = true;

            try
            {
                var result = await RestAPI.GetPublicacionesALL(1);
                if (result!=null)
                {
                    lPosts = new ObservableCollection<ResponsePublicacionFeed>(result);
                    Dialogos.ToastOk("Publicaciones actualizadas", 1500);
                }
                else
                {
                    Dialogos.ToastBAD("No es posible actualizar", 1200);
                }
            }
            catch (Exception ex)
            {
                Debug.Print($"Error en FeedViewmodel  --{ex.Message}");
                Debug.WriteLine("Is Busy");
            }
            finally
            {
                IsRefreshing = false;
            }
        }

        private async void Like(int idPostLike)
        {
            var like = new like_postModel
            {
                id_post = idPostLike,
                id_user = Singleton.Usuario.usuario.id_user
            };
            if (await RestAPI.Post<like_postModel>(like,TableName.like_postt))
            {
                Dialogos.ToastOk("Brot", 1000);
                //await App.Current.MainPage.DisplayAlert("EXITO", "Has presionado el boton " + idPostLike, "Ok");
            }
        }



        ////SOLO PRUBEA
        ////BORRAR CUANDO FUNCIONE EL API 
        //public void cargarImgs()
        //{
        //    ResponsePublicacionFeed p1 = new ResponsePublicacionFeed()
        //    {
        //        id_post = 1,
        //        descripcion = "Este es un post de prueba con imagen",
        //        fecha_actualizacion = DateTime.Now,
        //        fecha_creacion = DateTime.Now,
        //        id_user = 1,
        //        img = "https://py-softwaresv.com/wp-content/uploads/2019/08/Logo_Square_512-300x300.png",
        //        isimg = true
        //    };

        //    ResponsePublicacionFeed p2 = new ResponsePublicacionFeed()
        //    {
        //        id_post = 2,
        //        descripcion = "Este es un post de prueba sin imagen",
        //        fecha_actualizacion = DateTime.Now,
        //        fecha_creacion = DateTime.Now,
        //        id_user = 2,
        //        img = null,
        //        isimg = false
        //    };

        //    ResponsePublicacionFeed p3 = new ResponsePublicacionFeed()
        //    {
        //        id_post = 3,
        //        descripcion = "Este es otro post de prueba con imagen",
        //        fecha_actualizacion = DateTime.Now,
        //        fecha_creacion = DateTime.Now,
        //        id_user = 1,
        //        img = "https://py-softwaresv.com/wp-content/uploads/2019/08/Logo_Square_512-300x300.png",
        //        isimg = true
        //    };

        //    ResponsePublicacionFeed p4 = new ResponsePublicacionFeed()
        //    {
        //        id_post = 4,
        //        descripcion = "Este es otro post de prueba sin imagen",
        //        fecha_actualizacion = DateTime.Now,
        //        fecha_creacion = DateTime.Now,
        //        id_user = 2,
        //        img = null,
        //        isimg = false
        //    };

        //    this.lPosts.Add(p1);
        //    this.lPosts.Add(p2);
        //    this.lPosts.Add(p3);
        //    this.lPosts.Add(p4);
        //}
    }
}
