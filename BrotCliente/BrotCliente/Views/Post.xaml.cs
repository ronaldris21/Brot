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

            ResponsePublicacionFeed item = new ResponsePublicacionFeed()
            {
                id_post = 2,
                descripcion = "Default post without image",
                fecha_actualizacion = DateTime.Now,
                fecha_creacion = DateTime.Now,
                id_user = 2,
                img = null,
                isimg = false
            };

            BindingContext = ViewModel = new PostViewModel(item);
        }
    }
}