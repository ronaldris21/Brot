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
    public partial class BrotTen : ContentPage
    {
        private BrotTenViewModel ViewModel;
        public BrotTen()
        {
            InitializeComponent();

            BindingContext = ViewModel = new BrotTenViewModel();
        }
    }
}