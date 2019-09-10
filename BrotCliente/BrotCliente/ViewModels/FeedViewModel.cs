using BrotApi0.Models;
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
        public ObservableCollection<ResponsePublicacionFeed> lPosts { get; }

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
            cargarImgs();
        }

        public async void Refresh()
        {
            if (IsRefreshing)
                return;

            IsRefreshing = true;

            try
            {
                await App.Current.MainPage.DisplayAlert("Refresh", "Refreshing", "ok");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Is Busy");
            } finally
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
        public void cargarImgs()
        {
            ResponsePublicacionFeed p1 = new ResponsePublicacionFeed()
            {
                id_post = 1,
                descripcion = "Este es un post de prueba con imagen",
                fecha_actualizacion = DateTime.Now,
                fecha_creacion = DateTime.Now,
                id_user = 1,
                img = "https://py-softwaresv.com/wp-content/uploads/2019/08/Logo_Square_512-300x300.png",
                isimg = true
            };

            ResponsePublicacionFeed p2 = new ResponsePublicacionFeed()
            {
                id_post = 2,
                descripcion = "Este es un post de prueba sin imagen",
                fecha_actualizacion = DateTime.Now,
                fecha_creacion = DateTime.Now,
                id_user = 2,
                img = null,
                isimg = false
            };

            ResponsePublicacionFeed p3 = new ResponsePublicacionFeed()
            {
                id_post = 3,
                descripcion = "Este es otro post de prueba con imagen",
                fecha_actualizacion = DateTime.Now,
                fecha_creacion = DateTime.Now,
                id_user = 1,
                img = "https://py-softwaresv.com/wp-content/uploads/2019/08/Logo_Square_512-300x300.png",
                isimg = true
            };

            ResponsePublicacionFeed p4 = new ResponsePublicacionFeed()
            {
                id_post = 4,
                descripcion = "Este es otro post de prueba sin imagen",
                fecha_actualizacion = DateTime.Now,
                fecha_creacion = DateTime.Now,
                id_user = 2,
                img = null,
                isimg = false
            };

            this.lPosts.Add(p1);
            this.lPosts.Add(p2);
            this.lPosts.Add(p3);
            this.lPosts.Add(p4);
        }
    }
}
