using BrotCliente.ViewModels;
using BrotCliente.XamarinStyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms.Xaml;

namespace BrotCliente.Views.Tabs
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SellersMap : ContentPage
    {
        SellersMapViewModel ViewModel;
        public SellersMap()
        {
            InitializeComponent();


            XamarinMapStyle Style = new XamarinMapStyle();
            BindingContext = this.ViewModel = new SellersMapViewModel();
            this.MyMap.MapStyle = MapStyle.FromJson(Style.Text);

            this.MyMap.MoveToRegion(
                MapSpan.FromCenterAndRadius(
                    new Position(
                        13.994778,
                        -89.556642
                        ), 
                    Distance.FromMeters(2500)
                    )
                );

            this.ViewModel.InitPinsCommand.Execute(null);
        }

        private void MyMap_PinClicked(object sender, PinClickedEventArgs e)
        {
            ViewModel.LoadBottom();
        }
    }
}