using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.GoogleMaps;

namespace BrotCliente.ViewModels
{
    public class SellersMapViewModel : BaseViewModel
    {
        public ObservableCollection<Pin> Pins { get; set; }

        public ICommand InitPinsCommand
        {
            get
            {
                return new RelayCommand(InitPins);
            }
        }

        public SellersMapViewModel()
        {
            this.Pins = new ObservableCollection<Pin>();
        }

        public void InitPins()
        {
            Pin p1 = new Pin()
            {
                //Icon = BitmapDescriptorFactory.DefaultMarker(Color.Green),
                Icon = BitmapDescriptorFactory.FromBundle("pin100.png"),
                Label = "Brot 1",
                //Position(lat, long)
                Position = new Position(13.9803544047914, -89.7502448454499)
            };

            Pin p2 = new Pin()
            {
                Icon = BitmapDescriptorFactory.FromBundle("pin100.png"),
                Label = "Brot 2",
                //Position(lat, long)
                Position = new Position(13.9966387066901, -89.5510578900576)
            };

            Pin p3 = new Pin()
            {
                //Icon = BitmapDescriptorFactory.DefaultMarker(Color.Green),
                Icon = BitmapDescriptorFactory.FromBundle("pin100.png"),
                Label = "Brot 3",
                //Position(lat, long)
                Position = new Position(13.9804544047914, -89.5602448454499)
            };

            Pin p4 = new Pin()
            {
                Icon = BitmapDescriptorFactory.FromBundle("pin100.png"),
                Label = "Brot 4",
                //Position(lat, long)
                Position = new Position(13.9967097066901, -89.9610578900576)
            };

            this.Pins.Add(p1);
            this.Pins.Add(p2);
            this.Pins.Add(p3);
            this.Pins.Add(p4);
        }

        #region InCaseYouWantToAddPins
        /*     
        public ICommand MapClicked
        {
            get
            {
                return new RelayCommand<MapClickedEventArgs>(MapClick);
            }
        }
        
        private void MapClick(MapClickedEventArgs args)
        {
            this.Pins.Clear();
            this.Pins.Add(new Pin()
            {
                Label = "Hellow World!\nI'm a Pin",
                Position = args.Point
            });
            App.Current.MainPage.DisplayAlert("BIEN", string.Format("Si hace click\nLongitud: {0}\nLatitud: {1}", args.Point.Longitude, args.Point.Latitude), "OKAY");
        }*/
        #endregion
    }
}
