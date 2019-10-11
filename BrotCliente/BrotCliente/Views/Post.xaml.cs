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
    }
}