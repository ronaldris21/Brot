﻿namespace Brot.ViewModels
{
    using Brot.Patterns;
    using Brot.Services;
    using Brot.Views.Popups;
    using DLL;
    using Models;
    using Rg.Plugins.Popup.Services;
    using System;
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Windows.Input;
    using Xamarin.Forms.GoogleMaps;
    using Xamarin.Forms.Internals;

    public class SellersMapViewModel : BaseViewModel
    {
        public Map Mapa;
        private ObservableCollection<Pin> _places;
        private Pin _pin;
        public Pin pin
        {
            get
            {
                return _pin;
            }
            set
            {
                _pin = value;OnPropertyChanged("pin");
            }
        }
        public ObservableCollection<Pin> places
        {
            get
            {
                return _places;
            }
            set
            {
                _places = value; OnPropertyChanged("places");
            }
        }

        public ICommand InitPinsCommand
        {
            get
            {
                return new Xamarin.Forms.Command(InitPins);
            }
        }
        public SellersMapViewModel(ref Map map)
        {
            Mapa = map;
            InitPins();
        }
        public async void InitPins()
        {
            places = new ObservableCollection<Pin>();
            //TODO modificar controlador de Vendor
            var result = await RestClient.GetAll<userModel>("users/vendors/");

            if (!result.IsSuccess)
            {
                //await Singleton.Instance.Dialogs.Message("Error trying to get sellers", result.Message);
                return;
            }
            //api / categoria / GMC /{ id}
            //TODO Categoria en DB como nombres tal cual y AGREGAR .png AQU[I!!
            int i = 0;
            Singleton.Instance.AddStores((ObservableCollection<userModel>)result.Result);
            foreach (var seller in (ObservableCollection<userModel>)result.Result)
            {
                Pin pin = new Pin();
                //pin.Label = $"Seller name: {seller.username} Description: {seller.descripcion}";
                pin.Label = "";
                pin.Position = new Position(Convert.ToDouble(seller.xlat), Convert.ToDouble(seller.ylon));
                pin.Icon = BitmapDescriptorFactory.FromBundle(seller.imgCategoria);
                pin.ZIndex = i;
                pin.Type = PinType.Place;
                i++;
                places.Add(pin);
            }
        }
        public ICommand pinClicked
        {
            get
            {
                return new Xamarin.Forms.Command<int>(LoadBottom);
            }
        }
        public void LoadBottom(int id)
        {
            PopupNavigation.PushAsync(new mapPopup(Singleton.Instance.GetStore(id)));
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
    [Preserve(AllMembers = true)]
    class Place : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public string Address { get; }

        public string Description { get; }

        Position _position;
        public Position Position
        {
            get => _position;
            set
            {
                if (!_position.Equals(value))
                {
                    _position = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Position)));
                }
            }
        }

        int _iconNumber;
        public int IconNumber
        {
            get => _iconNumber;
            set
            {
                if (_iconNumber != value)
                {
                    _iconNumber = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IconNumber)));
                }
            }
        }

        public Place(string address, string description, Position position, int iconNumber)
        {
            Address = address;
            Description = description;
            Position = position;
            IconNumber = iconNumber;
        }
    }
}
