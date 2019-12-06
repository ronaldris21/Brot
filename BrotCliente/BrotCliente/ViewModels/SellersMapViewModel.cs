using DLL.Models;
using BrotCliente.Patterns;
using BrotCliente.Services;
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

        public async void InitPins()
        {
            var result = await RestClient.GetAll<userModel>("users/vendors/");

            if (!result.IsSuccess)
            {
                await Singleton.Instance.Dialogs.Message("Error trying to get sellers", result.Message);
                return;
            }

            foreach (var seller in (ObservableCollection<userModel>) result.Result)
            {
                Pin pin = new Pin()
                {
                    Icon = BitmapDescriptorFactory.FromBundle("pin100.png"),
                    Label = $"Seller name: {seller.username} Description: {seller.descripcion}",
                    Position = new Position(Convert.ToDouble(seller.xlat), Convert.ToDouble(seller.ylon))
                };

                this.Pins.Add(pin);
            }
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
