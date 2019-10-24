using BrotCliente.ViewModels;
using DLL.Models;
using DLL.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrotCliente.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SellerProfile : ContentPage
    {
        SellerProfileViewModel ViewModel;
        public SellerProfile(SellerProfileViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.ViewModel = viewModel;
        }

        public SellerProfile()
        {
            InitializeComponent();
            var item = new ResponseUserProfile()
            {
                UserProfile = new userModel()
                {
                    username = "Prueba",
                    puesto_name = "Prueba",
                    descripcion = "Lorem itsum"
                }
            };

            BindingContext = this.ViewModel = new SellerProfileViewModel(item);
        }
    }
}