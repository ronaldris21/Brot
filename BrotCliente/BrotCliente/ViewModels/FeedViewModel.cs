using BrotApi0.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BrotCliente.ViewModels
{
    class FeedViewModel : BaseViewModel
    {
        public ObservableCollection<publicaciones> lPosts { get; }

        public FeedViewModel()
        {
            this.lPosts = new ObservableCollection<publicaciones>();
            cargarImgs();
        }

        //SOLO PRUBEA
        //BORRAR CUANDO FUNCIONE EL API 
        public void cargarImgs()
        {
            publicaciones p1 = new publicaciones()
            {
                id_post = 1,
                descripcion = "Este es un post de prueba con imagen",
                fecha_actualizacion = DateTime.Now,
                fecha_creacion = DateTime.Now,
                id_user = 1,
                img = "https://py-softwaresv.com/wp-content/uploads/2019/08/Logo_Square_512-300x300.png"
            };

            publicaciones p2 = new publicaciones()
            {
                id_post = 2,
                descripcion = "Este es un post de prueba sin imagen",
                fecha_actualizacion = DateTime.Now,
                fecha_creacion = DateTime.Now,
                id_user = 2,
                img = null
            };

            this.lPosts.Add(p1);
            this.lPosts.Add(p2);
        }
    }
}
