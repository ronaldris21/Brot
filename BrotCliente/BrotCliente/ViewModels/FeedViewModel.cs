using BrotApi0.Models;
using DLL.ResponseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BrotCliente.ViewModels
{
    class FeedViewModel : BaseViewModel
    {
        public ObservableCollection<ResponsePublicacionFeed> lPosts { get; }

        public FeedViewModel()
        {
            this.lPosts = new ObservableCollection<ResponsePublicacionFeed>();
            cargarImgs();
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
                id_post = 1,
                descripcion = "Este es otro post de prueba con imagen",
                fecha_actualizacion = DateTime.Now,
                fecha_creacion = DateTime.Now,
                id_user = 1,
                img = "https://py-softwaresv.com/wp-content/uploads/2019/08/Logo_Square_512-300x300.png",
                isimg = true
            };

            ResponsePublicacionFeed p4 = new ResponsePublicacionFeed()
            {
                id_post = 2,
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
