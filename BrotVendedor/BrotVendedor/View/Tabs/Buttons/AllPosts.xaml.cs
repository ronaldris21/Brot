using BrotVendedor.ViewModel.Tabs.Buttons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrotVendedor.View.Tabs.Buttons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AllPosts : ContentPage
    {
        public AllPosts()
        {
            InitializeComponent();
            BindingContext = new AllPostsViewModel();
        }
    }
}