namespace BrotVendedor.ViewModel
{
    using BrotApi0.Models;
    using BrotVendedor.Class;
    using BrotVendedor.Model;
    using DLL.ResponseModels;
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Essentials;

    public class PostsViewModel : BaseViewModel
    {
        #region Atributos
        private ObservableCollection<ResponsePublicacionFeed> _posts;
        private String _texto;
        private ApiService api;
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
        public ObservableCollection<ResponsePublicacionFeed> posts
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
            api = new ApiService();
            posts = new ObservableCollection<ResponsePublicacionFeed>();
            LoadPost();
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
        public ICommand PLike
        {
            get
            {
                return new RelayCommand<int>(Like);
            }
        }
        public ICommand takePhoto
        {
            get
            {
                return new RelayCommand(Singleton.current.ChangePic);
            }
        }
        #endregion
        #region Metodos
        public async void LoadPost()
        {
            Response resp = await api.GetAll<ResponsePublicacionFeed>("publicaciones/feed/" + Singleton.current.user.id_user);
            posts = (ObservableCollection<ResponsePublicacionFeed>)resp.Result;
        }
        public async void AddPost()
        {
            publicacionesModel niu = new publicacionesModel();
            niu.fecha_creacion = DateTime.Now;
            niu.id_user =Singleton.current.user.id_user;
            if (PickPhotoAsync.name == null)
            {
                niu.img = null;
                niu.isImg = false;
            }
            else
            {
                niu.img = PickPhotoAsync.name;
                niu.isImg = true;
            }
            niu.descripcion = texto;
            niu.isDeleted = false;
            niu.fecha_actualizacion = null;
            texto = "";
            PickPhotoAsync.name = null;
            Response resp = await api.Post<publicacionesModel>("publicaciones", niu);
            if (!resp.isSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error",resp.Message,"Aceptar");
            }
        }
        public void Like(int arg)
        {
            //ResponsePublicacionFeed selec;

            //var x = from c in posts where c.publicacion.id_post == arg select c;
            //selec = x.First();

            //if (selec.like.Equals("NoLike.png"))
            //{
            //    selec.like = "Like.png";
            //}
            //else
            //{
            //    selec.like = "NoLike.png";
            //}
            //posts[posts.Count - 1 - selec.id_Post] = selec;
        }
      
        public void PhotoForPost()
        {

        }
        #endregion
    }
}



