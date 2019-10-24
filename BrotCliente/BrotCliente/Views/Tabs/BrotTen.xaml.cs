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

        private async void FeedListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selected = e.SelectedItem as ResponseUsuariosFiltro;

            if (selected == null)
                return;

            int id_userProfile = selected.userData.id_user;

            

            //await Navigation.PushAsync(new SellerProfile(new SellerProfileViewModel(item)));
            await Navigation.PushAsync(new SellerProfile(new SellerProfileViewModel(id_userProfile)));

            //Se quita la seleccion del item
            this.BrotTenList.SelectedItem = null;
        }
    }
}