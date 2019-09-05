namespace BrotVendedor.ViewModel
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Input;
    public struct Post
    {
        public String texto { get; set; }
        public String imgPath { get; set; }
        public String usuario { get; set; }
        public String hora { get; set; }
        public String img { get; set; }
    }

    public class PostsViewModel : BaseViewModel
    {
        #region Atributos
        private ObservableCollection<Post> _posts;
        private String _texto;
        #endregion
        #region Propiedades
        public String texto
        {
            get
            {
                return _texto;
            }
            set
            {
                _texto = value; OnPropertyChanged("texto");
            }
        }
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
        #endregion
        #region Constructor
        public PostsViewModel()
        {
            posts = new ObservableCollection<Post>();
            Post p = new Post
            {
                texto = "Post 1",
                imgPath = "userTab64x64.png",
                usuario = "SilkenHarbor6",
                hora = "15:05",
                img = "Bro.png"
            };
            Post p2 = new Post
            {
                texto = "Post 2",
                imgPath = "userTab64x64.png",
                usuario = "Ris",
                hora = "15:05",
                img = "Bro.png"
            };
            posts.Add(p);
            posts.Add(p2);

        }
        #endregion
        #region Command
        public ICommand PostSomething
        {
            get
            {
                return new RelayCommand(AddPost);
            }
        }
        #endregion
        #region Metodos
        public void AddPost()
        {
            Post niu = new Post();
            var h = DateTime.Now.ToString().Split(' ');
            var time = h[1].Split(':');
            niu.hora = time[0] + ":" + time[1];
            niu.usuario = "SilkenHarbor6";
            niu.imgPath = "userTab64x64.png";
            niu.img = "Bro.png";
            niu.texto = texto;
            posts.Insert(0, niu);
            texto = "";
        }
        #endregion
    }
}



