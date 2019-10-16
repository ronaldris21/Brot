using BrotVendedor.Class;
using BrotVendedor.Model;
using BrotVendedor.ViewModel;
using BrotVendedor.XStyles;
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
        public ChooseLocation(Usuario local,String estado)
        {
            InitializeComponent();
            Mape.MapStyle = MapStyle.FromJson(new XamMapStyle().text);
            if (Singleton.current.user!=null)
            {
                Mape.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(Singleton.current.user.xlat, Singleton.current.user.ylon), Distance.FromMeters(250)));
            }
            else
            {
                Mape.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(13.994778, -89.556642), Distance.FromMeters(250)));
            }
            BindingContext = new ChooseLocationViewModel(local,estado);
        }
    }
}