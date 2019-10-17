using BrotCliente.ViewModels;
using DLL.ResponseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

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

        private void ImageButton_ClickedPOST_Like(object sender, EventArgs e)
        {
            bool isliked;
            try
            {
                isliked = (bool)((ImageButton)sender).CommandParameter;
            }
            catch (Exception)
            {
                isliked = false;
            }
            //Saber si ya era like o no? Retorna FALSE para el pin negro y retorna True para el pin Naranja
            if (isliked)
            {
                ((ImageButton)sender).Source = "PinBlack250.png";
            }
            else
            {
                ((ImageButton)sender).Source = "Pin250.png";
            }
            ((ImageButton)sender).CommandParameter = !isliked;

            var postactualizado = ((PostViewModel)BindingContext).Post;
            postactualizado.publicacion.IsLiked = !isliked;
            ((PostViewModel)BindingContext).Post = postactualizado;


            ((PostViewModel)BindingContext).Post.publicacion.IsLiked = !isliked;


        }

        private void ImageButton_ClickedCOMMENT_Like(object sender, EventArgs e)
        {
            bool isliked = (bool)((ImageButton)sender).CommandParameter;
            //Saber si ya era like o no? Retorna FALSE para el pin negro y retorna True para el pin Naranja
            if (isliked)
            {
                ((ImageButton)sender).Source = "PinBlack.ico";
            }
            else
            {
                ((ImageButton)sender).Source = "Pin.ico";
            }
            ((ImageButton)sender).CommandParameter = !isliked;
        }
    }
}