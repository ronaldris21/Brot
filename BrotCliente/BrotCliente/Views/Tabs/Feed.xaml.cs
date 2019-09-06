using BrotCliente.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrotCliente.Views.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    [DesignTimeVisible(false)]
    public partial class Feed : ContentPage
    {
        FeedViewModel ViewModel;
        public Feed()
        {
            InitializeComponent();

            BindingContext = ViewModel = new FeedViewModel();
        }
    }
}