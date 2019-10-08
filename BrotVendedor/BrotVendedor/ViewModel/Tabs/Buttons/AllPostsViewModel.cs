using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BrotVendedor.ViewModel.Tabs.Buttons
{
    public struct Post
    {
        public int id_Post { get; set; }
        public String texto { get; set; }
        public String imgPath { get; set; }
        public String usuario { get; set; }
        public String hora { get; set; }
        public String img { get; set; }
        public String like { get; set; }
        public bool isimg { get; set; }
    }
    class AllPostsViewModel:BaseViewModel
    {
        private ObservableCollection<Post> _posts;
        public ObservableCollection<Post> posts
        {
            get
            {
                return _posts;
            }
            set
            {
                if (_posts != value)
                {
                    _posts = value; OnPropertyChanged("posts");
                }
            }
        }
        public AllPostsViewModel()
        {
            posts = new ObservableCollection<Post>();
            Post p = new Post
            {
                texto = "Post 1",
                imgPath = "userTab64x64.png",
                usuario = "SilkenHarbor6",
                hora = "15:05",
                img = "Bro.png",
                like = "NoLike.png",
                id_Post = posts.Count,
                isimg = true
            };
            posts.Insert(0, p);
            Post p2 = new Post
            {
                texto = "Post 2",
                imgPath = "userTab64x64.png",
                usuario = "Ris",
                hora = "15:05",
                img = "Bro.png",
                like = "NoLike.png",
                id_Post = posts.Count,
                isimg = false
            };
            posts.Insert(0, p2);
        }

    }
}
