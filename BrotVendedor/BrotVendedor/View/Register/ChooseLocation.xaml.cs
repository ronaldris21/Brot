using BrotVendedor.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace BrotVendedor.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ChooseLocation : ContentPage
    {
        public ChooseLocation()
        {
            InitializeComponent();
            Mape.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(13.994778, -89.556642), Distance.FromMeters(250)));
            BindingContext = new ChooseLocationViewModel();
        }
    }
}