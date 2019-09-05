using BrotApi0.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BrotVendedor.ViewModel
{
    public struct Post
    {
        public String texto;
        public String imgPath;
        public String usuario;
        public String hora;
        public String img;
    }

    public class PostsViewModel
    {
        public ObservableCollection<Post> posts { get; set; }
        public PostsViewModel()
        {
            posts = new ObservableCollection<Post>();
            Post p = new Post
            {
                texto = "Post 1",
                imgPath = "userTab64x64",
                usuario = "SilkenHarbor6",
                hora = "15:05",
                img = "Bro.png"
            };
            Post p2 = new Post
            {
                texto = "Post 1",
                imgPath = "userTab64x64",
                usuario = "Ris",
                hora = "15:05",
                img = "Bro.png"
            };
            posts.Add(p);
            posts.Add(p2);
           
        }
    }
}
