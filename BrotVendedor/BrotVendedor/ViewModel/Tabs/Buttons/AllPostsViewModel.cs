using DLL.Models;
using BrotVendedor.Class;
using BrotVendedor.Model;
using DLL.ResponseModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BrotVendedor.ViewModel.Tabs.Buttons
{
    class AllPostsViewModel:BaseViewModel
    {
        private ObservableCollection<ResponsePublicacionFeed> _posts;
        private ApiService api;
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
        public AllPostsViewModel()
        {
            api = new ApiService();
            LoadPosts();
        }
        public async void LoadPosts()
        {
            Response resp = await api.GetAll<ResponsePublicacionFeed>("publicaciones/all/"+Singleton.current.user.id_user);
            ObservableCollection<ResponsePublicacionFeed> temp = (ObservableCollection<ResponsePublicacionFeed>)resp.Result;
            foreach (var item in temp)
            {
                item.publicacion.img = "http://images.somee.com/Uploads/" + item.publicacion.img;
                item.UsuarioCreator.img= "http://images.somee.com/Uploads/" + item.UsuarioCreator.img;
            }
            ObservableCollection<ResponsePublicacionFeed> temp2 = new ObservableCollection<ResponsePublicacionFeed>();
            for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i].UsuarioCreator.id_user==Singleton.current.user.id_user)
                {
                    temp2.Add(temp[i]);
                }
            }
            posts = temp2;
        }
    }
}
