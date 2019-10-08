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
    [DesignTimeVisible(true)]
    public partial class Profile : ContentPage
    {
        private ProfileViewModel ViewModel;
        public Profile()
        {
            InitializeComponent();

            BindingContext = this.ViewModel = new ProfileViewModel();
        }
    }
}