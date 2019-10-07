using BrotVendedor.ViewModel;
using BrotVendedor.ViewModel.Tabs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BrotVendedor.View.Tabs.MasterPage.Detail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfileDetail : ContentPage
    {
        public ProfileDetail()
        {
            InitializeComponent();
            BindingContext = new ProfileDetailViewModel();
        }
    }
}