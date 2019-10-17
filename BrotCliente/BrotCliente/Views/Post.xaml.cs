using BrotCliente.Patterns;
using BrotCliente.Services;
using BrotCliente.ViewModels;
using DLL.Models;
using DLL.ResponseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using FFImageLoading.Forms;

namespace BrotCliente.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(true)]
    public partial class Post : ContentPage
    {
        private PostViewModel ViewModel;

        public Post(PostViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = viewModel;
        }
        public Post()
        {
            InitializeComponent();

            BindingContext = ViewModel = new PostViewModel(new ResponsePublicacionFeed());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }


        private async void ImageIconLikePost_Tapped(object sender, EventArgs e)
        {
            bool isliked;
            isliked = ((CachedImage)sender).AutomationId=="True"?true:false ;
            //Saber si ya era like o no? Retorna FALSE para el pin negro y retorna True para el pin Naranja
            var like = new like_postModel()
            {
                id_post = Convert.ToInt32(((CachedImage)sender).ClassId),
                id_user = Singleton.Instance.User.id_user
            };
            if (isliked)
            {
                //Se quita el like
                ((CachedImage)sender).Source = "PinBlack250.png";
                await RestClient.Post<like_postModel>("like_comentario/borrar", like);
            }
            else
            {
                //se crea el like!
                ((CachedImage)sender).Source = "Pin250.png";
                await RestClient.Post<like_postModel>("like_comentario", like);
            }
            ((CachedImage)sender).AutomationId = !isliked ? "True" : "False";

        }
    }
}